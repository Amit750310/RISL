using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.DirectoryServices.Protocols;

namespace ML
    {
        public class LdapService
        {
            private readonly string ldapHost;
            private readonly int ldapPort;
            private readonly string ldapUser;
            private readonly string ldapPassword;
            private readonly string baseDn;
            //private readonly bool useStartTls;

            public LdapService(
                string ldapHost,
                int ldapPort,
                string ldapUser,
                string ldapPassword,
                string baseDn)
            {
                this.ldapHost = ldapHost;
                this.ldapPort = ldapPort;
                this.ldapUser = ldapUser;
                this.ldapPassword = ldapPassword;
                this.baseDn = baseDn;
                //this.useStartTls = useStartTls;
            }

            public bool Authenticate(string username, string password)
            {
                try
                {
                    using (var ldapConnection = new LdapConnection(new LdapDirectoryIdentifier(ldapHost, ldapPort)))
                    {
                        // Set credentials for the bind operation
                        ldapConnection.Credential = new NetworkCredential(ldapUser, ldapPassword);
                        ldapConnection.AuthType = AuthType.Basic;

                        //// Start TLS if required
                        //if (useStartTls)
                        //{
                        //    ldapConnection.SessionOptions.StartTransportLayerSecurity(null);
                        //}

                        ldapConnection.Bind(); // Bind with the admin credentials

                        // Search filter and search request
                        string searchFilter = $"(uid={username})"; // Modify based on your LDAP structure
                        var searchRequest = new SearchRequest(
                            baseDn,
                            searchFilter,
                            SearchScope.Subtree,
                            null);

                        var searchResponse = (SearchResponse)ldapConnection.SendRequest(searchRequest);

                        if (searchResponse.Entries.Count == 0)
                        {
                            Console.WriteLine("User not found");
                            return false;
                        }

                        // Get the user's distinguished name (DN)
                        string userDn = searchResponse.Entries[0].DistinguishedName;

                        // Authenticate the user with their DN and password
                        using (var userLdapConnection = new LdapConnection(new LdapDirectoryIdentifier(ldapHost, ldapPort)))
                        {
                            userLdapConnection.AuthType = AuthType.Basic;
                            userLdapConnection.Credential = new NetworkCredential(userDn, password);
                            userLdapConnection.Bind(); // Try to bind with the user's credentials
                            Console.WriteLine("Authentication successful");
                            return true;
                        }
                    }
                }
                catch (LdapException ex)
                {
                    Console.WriteLine($"LDAP Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    return false;
                }
            }
        }

        class Program
        {
             void Main1(string[] args)
            {
                // Configuration settings
                string ldapHost = "ldap.example.com";
                int ldapPort = 389;
                string ldapUser = "cn=admin,dc=example,dc=com";
                string ldapPassword = "admin_password";
                string baseDn = "dc=example,dc=com";

                // Initialize LDAP service
                var ldapService = new LdapService(ldapHost, ldapPort, ldapUser, ldapPassword, baseDn);

                // Get user credentials from input (for testing purposes)
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                // Authenticate user
                bool isAuthenticated = ldapService.Authenticate(username, password);

                Console.WriteLine(isAuthenticated ? "User authenticated successfully." : "Invalid credentials.");
            }
        }
}
 