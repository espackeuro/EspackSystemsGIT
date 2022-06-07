using System;
using System.Data;
using System.Runtime.InteropServices;

namespace ConsoleTools
{
    public static class cMiscTools
    {
        public static string RunningOS
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return "Windows";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return "Linux";
                return "Other";
            }
        }

        // Return true if the obj is a numeric type (only for DB Types)
        public static bool IsNumericType(DbType dbObj)
        {
            string _stage = "Identifiying DbType";
            try
            {
                switch (dbObj)
                {
                    case DbType.Byte:
                    case DbType.SByte:
                    case DbType.UInt16:
                    case DbType.UInt32:
                    case DbType.UInt64:
                    case DbType.Int16:
                    case DbType.Int32:
                    case DbType.Int64:
                    case DbType.Decimal:
                    case DbType.Double:
                    case DbType.Single:
                    case DbType.Currency:
                    case DbType.VarNumeric:
                        return true;
                    default:
                        return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"[MiscTools.cs/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }
        // Return true if the obj is a numeric type
        public static bool IsNumericType(this object obj)
        {
            string _stage = "Getting object Type";
            try
            {
                return IsNumericType(obj.GetType());
            }
            catch (Exception ex)
            {
                throw new Exception($"[MiscTools.cs/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }
        // Return true if the Type is a numeric type
        public static bool IsNumericType(Type type)
        {
            string _stage = "Identifiying Type";
            try
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.Byte:
                    case TypeCode.SByte:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[MiscTools.cs/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }
    }
}


