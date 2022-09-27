using Newtonsoft.Json;
using System.Reflection;

namespace Keno.Admin
{
    public class PayTablesSingleton
    {
        private static PayTablesSingleton? _instance = null;
        private static Dictionary<string, Dictionary<int, int>>? _payTable;
        private PayTablesSingleton() {
            _payTable = new Dictionary<string, Dictionary<int, int>>();

            try
            {
                var file = $"C:\\Users\\bestw\\Projects\\KenoApp\\MultiCard4Keno\\Keno.Admin\\Settings\\PayTables\\payTableNinetyTwoPercent.json";

                using (StreamReader sr = new StreamReader(file))
                {
                    _payTable = JsonConvert
                        .DeserializeObject<Dictionary<string, Dictionary<int, int>>?>(sr.ReadToEnd());
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PayTablesSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayTablesSingleton();
                }

                return _instance;
            }
        }

    }
}