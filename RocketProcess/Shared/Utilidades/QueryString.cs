using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Shared.Utilidades
{
    public class QueryString : IDisposable
    {
        private List<string> Keys { get; set; }
        private List<string> Values { get; set; }

        public QueryString()
        {

        }

        public void Add(string key, string value)
        {
            if (Keys is null)
                Keys = new List<string>();
            if(Values is null)
                Values = new List<string>();

            Keys.Add(key);
            Values.Add(value);
        }

        public string ObtenerQueryString()
        {
            try
            {
                string query = "?";
                for (int i = 0; i < Keys.Count; i++)
                {
                    if (i > 0)
                        query += "&";

                    query += Keys[i].ToString() + "=" + Values[i];
                }
                return query;
            }
            catch (Exception ex)
            {
                return "ERROR : " + ex.Message;
            }
            finally
            {
                if (Keys != null && Keys.Count() > 0)
                    Keys.Clear();

                if (Values != null && Values.Count() > 0)
                    Values.Clear();
            }
        }

        public void Dispose()
        {
            Keys = null;
            Values = null;
        }
    }
}
