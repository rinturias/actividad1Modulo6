using Newtonsoft.Json;

namespace Api.Gateway.Grupo1.Utilitarios
{

    public  class USerializeObjeto
    {


        public static string serializarObjeto(object data)
        {
            var jsonPerResOri = JsonConvert.SerializeObject(data);

            return jsonPerResOri;
        }
        public static List<T> serializaObjet_deserializeJsomObjet<T>(dynamic data)
        {
            //var jsonPerResOri = JsonConvert.SerializeObject(data);
            List<T> deserialize = JsonConvert.DeserializeObject<List<T>>(data);
            return deserialize;
        }
        public static T ConvertirObjeto<T>(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            var test = JsonConvert.DeserializeObject<T>(json);
            return test;
        }
        public static List<T> ConvertirListObjeto<T>(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            var test = JsonConvert.DeserializeObject<List<T>>(json);
            return test;
        }
        public static List<dynamic> deserializeJsom_Objeto(String dataJsom)
        {
            List<dynamic> deserializedProduct = JsonConvert.DeserializeObject<List<dynamic>>(dataJsom);

            return deserializedProduct;
        }
        public static List<T> deserializeJsom_ObjetoList<T>(String dataJsom)
        {
            List<T> deserializedProduct = JsonConvert.DeserializeObject<List<T>>(dataJsom);

            return deserializedProduct;
        }

    }


}
