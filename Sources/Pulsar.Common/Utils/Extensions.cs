using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Pulsar.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common
{
    public static class Extensions
    {
        public static IAbstractExtensions AbstractExtensions { get; set; }
        public static Task<List<T>> ToListAsync<T>(IQueryable<T> queryable)
        {
            return AbstractExtensions.ToListAsync(queryable);
        }
        public static Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable)
        {
            return AbstractExtensions.FirstOrDefaultAsync(queryable);
        }
        public static Task<T> FirstAsync<T>(IQueryable<T> queryable)
        {
            return AbstractExtensions.FirstAsync(queryable);
        }
        public static T FromBson<T>(this string str)
        {
            return BsonSerializer.Deserialize<T>(str);
        }
        public static string ToBson<T>(this T obj)
        {
            return obj.ToBsonDocument().ToJson();
        }
        public static IEnumerable<List<T>> Partition<T>(this IEnumerable<T> e, int partitionSize)
        {
            List<T> list = null;
            foreach (var item in e)
            {
                if (list == null)
                    list = new List<T>();

                if(list.Count >= partitionSize)
                {
                    yield return list;
                    list = new List<T>();
                }

                list.Add(item);
            }

            if (list.Count != 0)
                yield return list;
        }
        public static bool IsEmpty(this string text) => string.IsNullOrWhiteSpace(text);
        public static bool IsNotEmpty(this string text) => !string.IsNullOrWhiteSpace(text);
        public static string SHA256Hash(this string text)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var data = sha256Hash.ComputeHash(Encoding.GetEncoding("ISO-8859-1").GetBytes(text));
                var sBuilder = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2").ToLowerInvariant());
                }

                return sBuilder.ToString();
            }
        }
        public static string OnlyNumbers(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            return new string(text.Where(c => char.IsDigit(c)).ToArray());
        }
        public static bool IsCNS(this string cns)
        {
            if (cns == null || cns.Trim().Length != 15)
                return false;

            if (cns.StartsWith("1") || cns.StartsWith("2"))
            {
                float soma;
                float resto, dv;
                var pis = "";
                var resultado = "";
                pis = cns.Substring(0, 11);
                soma = (Convert.ToInt32(pis.Substring(0, 1)) * 15) +
                        (Convert.ToInt32(pis.Substring(1, 1)) * 14) +
                        (Convert.ToInt32(pis.Substring(2, 1)) * 13) +
                        (Convert.ToInt32(pis.Substring(3, 1)) * 12) +
                        (Convert.ToInt32(pis.Substring(4, 1)) * 11) +
                        (Convert.ToInt32(pis.Substring(5, 1)) * 10) +
                        (Convert.ToInt32(pis.Substring(6, 1)) * 9) +
                        (Convert.ToInt32(pis.Substring(7, 1)) * 8) +
                        (Convert.ToInt32(pis.Substring(8, 1)) * 7) +
                        (Convert.ToInt32(pis.Substring(9, 1)) * 6) +
                        (Convert.ToInt32(pis.Substring(10, 1)) * 5);
                resto = soma % 11;
                dv = 11 - resto;

                if (dv == 11)
                    dv = 0;


                if (dv == 10)
                {
                    soma += 2;

                    resto = soma % 11;
                    dv = 11 - resto;
                    resultado = pis + "001" + dv.ToString();
                }
                else
                    resultado = pis + "000" + dv.ToString();

                return cns.Equals(resultado);
            }

            if (cns.StartsWith("7") || cns.StartsWith("8") || cns.StartsWith("9"))
            {
                float resto, soma;
                soma = (Convert.ToInt32(cns.Substring(0, 1)) * 15) +
                        (Convert.ToInt32(cns.Substring(1, 1)) * 14) +
                        (Convert.ToInt32(cns.Substring(2, 1)) * 13) +
                        (Convert.ToInt32(cns.Substring(3, 1)) * 12) +
                        (Convert.ToInt32(cns.Substring(4, 1)) * 11) +
                        (Convert.ToInt32(cns.Substring(5, 1)) * 10) +
                        (Convert.ToInt32(cns.Substring(6, 1)) * 9) +
                        (Convert.ToInt32(cns.Substring(7, 1)) * 8) +
                        (Convert.ToInt32(cns.Substring(8, 1)) * 7) +
                        (Convert.ToInt32(cns.Substring(9, 1)) * 6) +
                        (Convert.ToInt32(cns.Substring(10, 1)) * 5) +
                        (Convert.ToInt32(cns.Substring(11, 1)) * 4) +
                        (Convert.ToInt32(cns.Substring(12, 1)) * 3) +
                        (Convert.ToInt32(cns.Substring(13, 1)) * 2) +
                        (Convert.ToInt32(cns.Substring(14, 1)) * 1);
                resto = soma % 11;
                return resto == 0;
            }

            return false;
        }
        public static bool IsCPF(this string cpf)

        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
        public static string Tokenize(this string str) => Pulsar.Common.Tokenize.Perform(str);
        public static bool Permite(this Sexo? sexo, Sexo outro)
        {
            if (sexo == null)
                return true; //permite ambos
            return sexo == outro;
        }
        public static bool ValidoParaCriacao(this TipoAtendimento ta)
        {
            switch (ta)
            {
                case TipoAtendimento.Medico:
                case TipoAtendimento.Enfermagem:
                case TipoAtendimento.AuxiliarEnfermagem:
                case TipoAtendimento.Vacinacao:
                case TipoAtendimento.Odontologico:
                case TipoAtendimento.AlteracaoProntuario:
                case TipoAtendimento.EscutaInicial:
                    return true;
                default:
                    return false;
            }
        }
        public static bool Contains(this (TimeSpan, TimeSpan) parente, TimeSpan ponto) => ponto >= parente.Item1 && ponto <= parente.Item2;
        public static bool StrictlyContains(this (TimeSpan, TimeSpan) parente, TimeSpan ponto) => ponto > parente.Item1 && ponto < parente.Item2;
        public static bool Contains(this (DateTime, DateTime) parente, DateTime ponto) => ponto >= parente.Item1 && ponto <= parente.Item2;
        public static bool StrictlyContains(this (DateTime, DateTime) parente, DateTime ponto) => ponto > parente.Item1 && ponto < parente.Item2;
        public static bool Contains(this (TimeSpan, TimeSpan) parente, TimeSpan inicio, TimeSpan fim) => parente.Contains(inicio) && parente.Contains(fim);
        public static bool StrictlyContains(this (TimeSpan, TimeSpan) parente, TimeSpan inicio, TimeSpan fim) => parente.StrictlyContains(inicio) && parente.StrictlyContains(fim);
        public static bool Contains(this (DateTime, DateTime) parente, DateTime inicio, DateTime fim) => parente.Contains(inicio) && parente.Contains(fim);
        public static bool StrictlyContains(this (DateTime, DateTime) parente, DateTime inicio, DateTime fim) => parente.StrictlyContains(inicio) && parente.StrictlyContains(fim);
        public static bool Intersects(this (TimeSpan, TimeSpan) parente, TimeSpan inicio2, TimeSpan fim2) => parente.Item1 <= fim2 && inicio2 <= parente.Item2;
        public static bool StrictlyIntersects(this (TimeSpan, TimeSpan) parente, TimeSpan inicio2, TimeSpan fim2) => parente.Item1 < fim2 && inicio2 < parente.Item2;
        public static bool Intersects(this (DateTime, DateTime) parente, DateTime inicio2, DateTime fim2) => parente.Item1 <= fim2 && inicio2 <= parente.Item2;
        public static bool StrictlyIntersects(this (DateTime, DateTime) parente, DateTime inicio2, DateTime fim2) => parente.Item1 < fim2 && inicio2 < parente.Item2;
        public static Dictionary<TKey, List<T>> PartitionBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> key)
        {
            Dictionary<TKey, List<T>> dic = new Dictionary<TKey, List<T>>();
            foreach (var item in items)
            {
                var k = key(item);
                if (!dic.ContainsKey(k))
                    dic[k] = new List<T>();

                dic[k].Add(item);
            }
            return dic;
        }
        public static Dictionary<TKey, T> PartitionByUnique<T, TKey>(this IEnumerable<T> items, Func<T, TKey> key)
        {
            Dictionary<TKey, T> dic = new Dictionary<TKey, T>();
            foreach (var item in items)
            {
                var k = key(item);
                dic[k] = item;
            }
            return dic;
        }
        public static Dictionary<TKey, TValue> Aggregate<TKey, TValue>(this Dictionary<TKey, List<TValue>> dictionary, 
            Func<TValue, TValue, TValue> aggregate,
            TValue defaultValue = default(TValue))
        {
            Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
            foreach (var key in dictionary.Keys)
            {
                if (dictionary[key] == null || dictionary[key].Count == 0)
                    dic[key] = defaultValue;
                else
                {
                    var list = dictionary[key];
                    var v = list[0];
                    for (int i = 1; i < list.Count; i++)
                    {
                        v = aggregate(v, list[i]);
                    }
                    dic[key] = v;
                }
            }
            return dic;
        }

        public static long ToUnix(this DateTime date)
        {
            var data = new DateTimeOffset(date);
            return data.ToUnixTimeMilliseconds();
        }
    }
}
