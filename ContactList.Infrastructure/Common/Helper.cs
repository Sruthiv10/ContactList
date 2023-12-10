using RFL.TechStack.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.Common
{
    /// <summary>
    /// Helper Class.
    /// </summary>
    public static class Helper
    {
        private static Random random = new Random();

        /// <summary>
        /// Enum object declaration.
        /// </summary>
        public class EnumModel
        {
            /// <summary>
            /// Gets or sets enum Value.
            /// </summary>
            public int EnumValue { get; set; }

            /// <summary>
            /// Gets or sets enum Description.
            /// </summary>
            public string EnumDescription { get; set; }
        }

        /// <summary>
        /// Generate Random numbers.
        /// </summary>
        /// <param name="length">length.</param>
        /// <returns>type.</returns>
        public static List<int> GenerateRandom(int length)
        {
            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();
            while (candidates.Count < length)
            {
                // May strike a duplicate.
                candidates.Add(random.Next());
            }

            // load them in to a list.
            List<int> result = new List<int>();
            result.AddRange(candidates);

            // shuffle the results:
            int i = result.Count;
            while (i > 1)
            {
                i--;
                int k = random.Next(i + 1);
                int value = result[k];
                result[k] = result[i];
                result[i] = value;
            }

            return result;
        }

        /// <summary>
        /// Clone from a list object.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="toClone">Destination.</param>
        /// <returns>Type.</returns>
        [ObsoleteAttribute("This method will soon be deprecated as T should be serializable. Use ToList().DeepClone instead.")]
        public static T DeepClone<T>(this T toClone)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, toClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Get Culture.
        /// </summary>
        /// <returns>response.</returns>
        public static CultureInfo GetCulture()
        {
            return new CultureInfo("en-GB");
        }

        /// <summary>
        /// Expression tree.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="left">left.</param>
        /// <param name="right">right.</param>
        /// <returns>response.</returns>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var body = Expression.AndAlso(
                    Expression.Invoke(left, param),
                    Expression.Invoke(right, param));
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
            return lambda;
        }

        /// <summary>
        /// Helper method for casting List to DataTable.
        /// </summary>
        /// <typeparam name="T">Entity Type.</typeparam>
        /// <param name="items">List of entities.</param>
        /// <returns>Data Table.</returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties by using reflection
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                // Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    // For solving Sql Exception c# datetime to sql datetime
                    if (props[i].PropertyType == typeof(DateTime))
                    {
                        values[i] = ((DateTime)props[i].GetValue(item, null)).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    }
                    else
                    {
                        values[i] = props[i].GetValue(item, null);
                    }
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        /// <summary>
        /// Encryption.
        /// </summary>
        /// <param name="plainText">string val..</param>
        /// <param name="keyValue">keyValue.</param>
        /// <returns>string.</returns>
        public static string Encryption(string plainText, string keyValue)
        {
            TripleDES des = CreateDES("Reflections_TRM" + keyValue);
            ICryptoTransform ct = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(plainText);
            byte[] buffer = ct.TransformFinalBlock(input, 0, input.Length);
            string value = Convert.ToBase64String(buffer);
            return value;
        }

        /// <summary>
        /// Encryption.
        /// </summary>
        /// <param name="cypherText">string val..</param>
        /// <param name="keyValue">keyValue.</param>
        /// <returns>string.</returns>
        public static string Decryption(string cypherText, string keyValue)
        {
            byte[] b = Convert.FromBase64String(cypherText);
            TripleDES des = CreateDES("Reflections_TRM" + keyValue);
            ICryptoTransform ct = des.CreateDecryptor();
            byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }

        /// <summary>
        /// Get date from epoch.
        /// </summary>
        /// <param name="unixTime">unixTime.</param>
        /// <returns>Response.</returns>
        public static DateTime FromUnixTime(long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Method for validate ISO 8601.
        /// </summary>
        /// <returns>dictionary object.</returns>
        public static bool ValidateISO8601DateTimeString(string datetime)
        {
            //2018-09-18T06:39:51Z
            DateTime result = new DateTime(); //If Parsing succeed, it will store date in result variable.
            return DateTime.TryParseExact(datetime, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        /// <summary>
        /// Method for get date in ISO 8601.
        /// </summary>
        /// <returns>dictionary object.</returns>
        public static DateTime GetDatefromISO8601String(string datetime)
        {
            //2018-09-18T06:39:51Z
            DateTime result = new DateTime(); //If Parsing succeed, it will store date in result variable.
            DateTime.TryParseExact(datetime, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
            return result;
        }

        /// <summary>
        /// Method for getting all enums in a dictionary.
        /// </summary>
        /// <returns>dictionary object.</returns>
        public static IDictionary<string, List<EnumModel>> GetEnumList()
        {
            object enumValue;
            string[] arrEnumNames;
            IDictionary<string, List<EnumModel>> result = new Dictionary<string, List<EnumModel>>();
            Type enumType;
            FieldInfo field;
            MemberInfo member;
            MemberInfo[] members = typeof(Enums).GetMembers(); // VJ provide your class name  typeof(<class name>)
            for (int i = 0; i < members.Length; i++)
            {
                member = members[i];

                if (member.MemberType == MemberTypes.NestedType)
                {
                    enumType = Type.GetType(member.DeclaringType.FullName + "+" + member.Name);

                    if (enumType.IsEnum)
                    {
                        arrEnumNames = enumType.GetEnumNames();
                        List<EnumModel> enumList = new List<EnumModel>();
                        foreach (string name in arrEnumNames)
                        {
                            field = enumType.GetField(name);
                            enumValue = field.GetRawConstantValue();
                            var descriptionAttributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                            var enumLabel = descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : "[Empty]";
                            enumList.Add(new EnumModel()
                            {
                                EnumDescription = enumLabel,
                                EnumValue = (int)enumValue
                            });
                        }

                        result.Add(member.Name, enumList);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// epoch time.
        /// </summary>
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Encryption.
        /// </summary>
        /// <param name="key">string val..</param>
        /// <returns>string.</returns>
        private static TripleDES CreateDES(string key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static string GetInOutboundEventName(string eventDesc)
        {
            var result = string.Empty;

            foreach (Enums.WebhookEvents item in Enum.GetValues(typeof(Enums.WebhookEvents)))
            {
                if (Helper.GetEnumDescription(item).ToLower() == eventDesc.ToLower())
                {
                    result = item.ToString();
                    break;
                }
            }
            return result;
        }

        public static string GetInOutboundProviderId(string providerDesc)
        {
            var result = string.Empty;
            foreach (Enums.WarehouseProvider item in Enum.GetValues(typeof(Enums.WarehouseProvider)))
            {
                if (Helper.GetEnumDescription(item).ToLower() == providerDesc.ToLower())
                {
                    result = item.ToString();
                    break;
                }
            }
            return result;
        }
    }
}
