namespace PSS.Utils.Constants
{
    public static class General
    {
        public const byte DESCRIPTION_MIN_LENGTH = 2;
        public const byte DESCRIPTION_MAX_LENGTH = 100;
        public const byte UF_LENGTH = 2;
        public const byte CEP_LENGTH = 9;
        public const byte CPF_LENGTH = 14;
        public const byte CNPJ_LENTH = 18;
        public const byte PASSWORD_MIN_LENGTH = 1;
        public const byte PASSWORD_MAX_LENGTH = 16;

        public const string REAL_VALUE_MASK = "{0:n2}";
        public const string CEP_MASK = "{0:#####-###}";
        public const string CPF_MASK = "{0:###.###.###-##}";
        public const string CNPJ_MASK = "{0:##.###.###/####-##}";
    }
}