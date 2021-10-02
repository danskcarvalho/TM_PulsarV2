using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pulsar.Common
{
    public struct Idade : IEquatable<Idade>, IComparable<Idade>
    {
        public static readonly Idade ZeroAnos = new Idade();

        public Idade(int anos, int meses, int dias)
        {
            if (anos < 0)
                throw new ArgumentOutOfRangeException("anos");
            if (meses < 0)
                throw new ArgumentOutOfRangeException("meses");
            if (dias < 0)
                throw new ArgumentOutOfRangeException("dias");

            Anos = anos;
            Meses = meses;
            Dias = dias;
        }

        public Idade(int anos, int meses)
        {
            if (anos < 0)
                throw new ArgumentOutOfRangeException("anos");
            if (meses < 0)
                throw new ArgumentOutOfRangeException("meses");

            Anos = anos;
            Meses = meses;
            Dias = 0;
        }

        public Idade(int anos)
        {
            if (anos < 0)
                throw new ArgumentOutOfRangeException("anos");

            Anos = anos;
            Meses = 0;
            Dias = 0;
        }

        public int Anos { get; }
        public int Meses { get; }
        public int Dias { get; }
        public int TotalMeses => Anos * 12 + Meses;
        public int TotalDias => Anos * 12 + Meses * 30 + Dias;

        public static Idade? TentarCalcular(DateTime dataNascimento, DateTime dataReferencia)
        {
            dataNascimento = dataNascimento.Date;

            if (dataNascimento > dataReferencia.Date)
                return null;

            return Calcular(dataNascimento, dataReferencia);
        }

        public static Idade Calcular(DateTime dataNascimento, DateTime dataReferencia)
        {
            var now = dataReferencia.Date;
            dataNascimento = dataNascimento.Date;

            if (dataNascimento > now)
                throw new ArgumentException("Data de nascimento no futuro.", nameof(dataNascimento));

            var months = now.Month - dataNascimento.Month + 12 * (now.Year - dataNascimento.Year);

            if (dataNascimento.AddMonths(months) > now)
                months--;
            if (dataNascimento.AddMonths(months + 1) < now)
                months++;

            var years = months / 12;
            months -= 12 * years;

            var startOfMonth = dataNascimento.AddYears(years).AddMonths(months);
            var days = (int)(now - startOfMonth).Duration().TotalDays;

            return new Idade(years, months, days);
        }

        public static Idade Calcular(DateTime dataNascimento) => Calcular(dataNascimento, DateTime.Now);

        public static Idade FromMeses(int meses)
        {
            var anos = meses / 12;
            meses -= anos * 12;

            return new Idade(anos, meses);
        }

        public static Idade FromDias(int dias)
        {
            var meses = dias / 30;
            dias -= meses * 30;
            var anos = meses / 12;
            meses -= anos * 12;

            return new Idade(anos, meses, dias);
        }

        public override string ToString()
        {
            return $"{Anos} anos, {Meses} meses e {Dias} dias";
        }

        public override int GetHashCode()
        {
            var hashcode = 31 * Anos;
            hashcode = 31 * hashcode + Meses;
            hashcode = 31 * hashcode + Dias;
            return hashcode;
        }

        public bool Equals(Idade other)
        {
            return Anos == other.Anos && Meses == other.Meses && Dias == other.Dias;
        }

        public override bool Equals(object obj)
        {
            return obj is Idade idade && Equals(idade);
        }

        public int CompareTo(Idade other)
        {
            if (Anos == other.Anos)
            {
                if (Meses == other.Meses)
                {
                    return Dias - other.Dias;
                }

                return Meses - other.Meses;
            }

            return Anos - other.Anos;
        }

        public static bool operator ==(Idade i1, Idade i2)
        {
            return i1.Equals(i2);
        }

        public static bool operator !=(Idade i1, Idade i2)
        {
            return !i1.Equals(i2);
        }

        public static bool operator <(Idade i1, Idade i2)
        {
            return i1.CompareTo(i2) < 0;
        }

        public static bool operator >(Idade i1, Idade i2)
        {
            return i1.CompareTo(i2) > 0;
        }

        public static bool operator <=(Idade i1, Idade i2)
        {
            return i1.CompareTo(i2) <= 0;
        }

        public static bool operator >=(Idade i1, Idade i2)
        {
            return i1.CompareTo(i2) >= 0;
        }
    }
}
