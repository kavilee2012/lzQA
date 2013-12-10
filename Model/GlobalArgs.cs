using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GlobalArgs
    {
        public static int OrganID;//机构编号
        public static DateTime SystemTime { get { return new DateTime(); } } //当前系统时间

        public static string CheckScorePath = @"~/UploadFiles/CheckScore/";
        public static string EmployeePath = @"~/UploadFiles/Employee/";
        public static string VehiclePath = @"~/UploadFiles/Vehicle/";
        public static string KilometrePath = @"~/UploadFiles/Kilometre/";
        public static string GpsPath = @"~/UploadFiles/Gps/";
        public static string RepairPath = @"~/UploadFiles/Repair/";
    }
}
