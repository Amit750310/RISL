using System;
namespace ML
{
    public class clsMenuMasterML
    {
        public string menuImage { get; set; }
        public string menuName { get; set; }
        public string menuPage { get; set; }
        public string menuTitle { get; set; }
        public string P_Out { get; set; }
        public string childeStatus { get; set; }

        public string RollId { get; set; }
        public string RollName { get; set; }
        public string RollActive { get; set; }
    }
    public class clsmenulist
    {

        public string menuid { get; set; }
        public string mode { get; set; }
    }
    public class clsLeftsideML
    {

        public string childeStatus { get; set; }
        public string loginEmpId { get; set; }
        public string menuId { get; set; }
        public string menuImage { get; set; }
        public string menuName { get; set; }
        public string menuPage { get; set; }
    }
    public class clsLeftsidechiledmenuML
    {
        public string childemenuId { get; set; }
        public string childeMenuImage { get; set; }
        public string childeMenuName { get; set; }
        public string childeMenuPage { get; set; }
        public string childeMenuTitle { get; set; }
        public string loginEmpId { get; set; }
        public string menuId { get; set; }
    }
}
