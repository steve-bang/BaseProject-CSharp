
using System.Text;

namespace SBase.Helper
{
    public class HttpHelper
    {
        /// <summary>
        /// Build the query string from the parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string CreateQueryParam(IDictionary<string, object> parameters)
        {
            if (parameters == null)
            {
                return string.Empty;
            }

            var param = new StringBuilder();

            // Loop through all the parameters
            foreach (var item in parameters)
            {
                param.Append($"{item.Key}={item.Value}&");
            }

            // Remove the last character "&"
            param = param.Remove(param.Length - 1, 1);

            return param.ToString();
        }

        public static string CreateQueryParam(string url, IDictionary<string, object> parameters)
        {
            string param = CreateQueryParam(parameters);

            return string.Concat(url, Characters.QuestionMark, param);
        }
    }
}
