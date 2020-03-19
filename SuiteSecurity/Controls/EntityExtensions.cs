using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SynapseCore.Database;

namespace SynapseCore.Controls
{
    public static class EntityExtensions
    {
        public static string GetHash<T>(this object instance) where T : HashAlgorithm, new()
        {
            T cryptoServiceProvider = new T();
            return computeHash(instance, cryptoServiceProvider);
        }

        /// <summary>
        ///     Gets a key based hash of the current instance.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of the Cryptographic Service Provider to use.
        /// </typeparam>
        /// <param name="instance">
        ///     The instance being extended.
        /// </param>
        /// <param name="key">
        ///     The key passed into the Cryptographic Service Provider algorithm.
        /// </param>
        /// <returns>
        ///     A base 64 encoded string representation of the hash.
        /// </returns>
        public static string GetKeyedHash<T>(this object instance, byte[] key) where T : KeyedHashAlgorithm, new()
        {
            T cryptoServiceProvider = new T { Key = key };
            return computeHash(instance, cryptoServiceProvider);
        }

        /// <summary>
        ///     Gets a MD5 hash of the current instance.
        /// </summary>
        /// <param name="instance">
        ///     The instance being extended.
        /// </param>
        /// <returns>
        ///     A base 64 encoded string representation of the hash.
        /// </returns>
        public static string GetMD5Hash(this object instance)
        {
            return instance.GetHash<MD5CryptoServiceProvider>();
        }

        public static string GetHashPerso(this object instance)
        {
            StringBuilder sb = new StringBuilder();
            Type objectType = instance.GetType();
            FieldInfo EcludeForSave = objectType.GetField("_EcludeForSave", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            IList<PropertyInfo> lprop = objectType.GetProperties();

            Char decSep = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            String val = "";
            int decPos = -1;
            // CDC525  16042013 only add an 'order by' .OrderBy(n => n.Name)
            foreach (PropertyInfo pi in lprop.OrderBy(n => n.Name))
            {
                try
                {
                    if (pi.Name != "IsDirty" && pi.Name != "InitialValue" && pi.GetValue(instance, null) != null && !DBFunction.mustBeExcluded(EcludeForSave.GetValue(null).ToString(), pi.Name))
                    {
                        // Begin CDC525 09022015 changed code because it doesn't work for decimal. For example 1,000 <> 1
                        val = pi.GetValue(instance, null).ToString();
                        if (pi.PropertyType.FullName.ToString() == "System.Decimal")
                        {
                            decPos = val.LastIndexOf(decSep);
                            if (decPos > -1)
                                val = val.TrimEnd('0').TrimEnd(decSep);
                        }
                        // old code = sb.AppendLine(pi.GetValue(instance, null).ToString());
                        // End CDC525 09022015
                        sb.AppendLine(val);
                    }
                    else
                        sb.AppendLine("#" + pi.Name + "=null#");
                }
                // TODO: Replace by more specific exception e.g. the ones documented here: http://msdn.microsoft.com/en-us/library/vstudio/c0bb9ctc(v=vs.90).aspx
                catch (Exception ex)
                {
                    sb.AppendLine("##");
                }

            }
            return sb.GetMD5Hash();
        }

        /// <summary>
        ///     Gets a SHA1 hash of the current instance.
        /// </summary>
        /// <param name="instance">
        ///     The instance being extended.
        /// </param>
        /// <returns>
        ///     A base 64 encoded string representation of the hash.
        /// </returns>
        public static string GetSHA1Hash(this object instance)
        {
            return instance.GetHash<SHA1CryptoServiceProvider>();
        }

        private static string computeHash<T>(object instance, T cryptoServiceProvider) where T : HashAlgorithm, new()
        {
            if (instance.GetType().IsSerializable)
            {
                DataContractSerializer serializer = new DataContractSerializer(instance.GetType());
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    serializer.WriteObject(memoryStream, instance);
                    cryptoServiceProvider.ComputeHash(memoryStream.ToArray());
                    return Convert.ToBase64String(cryptoServiceProvider.Hash);
                }
            }
            else
            {
                MessageBox.Show(instance.GetType().FullName + " Is not serialisable");
                return string.Empty;
            }
        }

        #region Entity Collection Extensions
        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static void SaveCollection<T>(this IList<T> List)
        {
            if (List.All(o => IsSubclassOfRawGeneric(typeof(SynapseCore.Entities.SynapseEntity<>), o.GetType())))
            {

                foreach (T e in from et in List where Convert.ToBoolean(et.GetType().GetProperty("IsDirty").GetValue(et, null)) == true select et)
                {
                    e.GetType().InvokeMember("save", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, e, null);
                }
            }
        }

        public static void SaveCollection<T>(this List<T> List)
        {
            if (List.All(o => IsSubclassOfRawGeneric(typeof(SynapseCore.Entities.SynapseEntity<>), o.GetType())))
            {

                foreach (T e in from et in List where Convert.ToBoolean(et.GetType().GetProperty("IsDirty").GetValue(et, null)) == true select et)
                {
                    e.GetType().InvokeMember("save", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, e, null);
                }
            }
        }
        #endregion
    }
}
