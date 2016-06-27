using System;
using System.Drawing;


namespace EasyAsDriverTraining
{
    class Gobal
    {
        public static String GRoleId;
        public static String GUserId;
        public static String GUserName;
        public static String OfficeConnString;
        public static String ConnString;
        public static String GConnStatus;
        public static String Errlog = "EasyAsDriverTraining.log";
        public static String Permfile = "EasyAsDriverTraining.app.config";
        public static Font Myfont = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        public static Font MyfontSmall = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        public static Font MyfontStrikeOut = new Font("Arial", 10F, FontStyle.Regular | FontStyle.Strikeout, GraphicsUnit.Point, ((byte)(0)));
        
    }
}
