using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IDEXlan.Expresiones
{
   public  class ExpresionesReg
    {
        public const string letra = "[a-z|A-Z]";
        public const string digito = "[0-9]";
        public const string OpLog = "[&|\u007c\u007c|&&|!]";
        public const string OpRel = "[<|>|=|>=|<=|==|!=]";
        public const string OpUni = "[\u002B]{2}$|[--]{2}$";
        public const string esp = "[\u0020]";
        public const string CarEsp = "[\u005d|\u0040|\u0028|\u0029|{|}|#|\u003f|\u005b]";
        public const string OpMat = "[-|\u002b|\u002a|%|/]";
        public const string Num = digito + "+";
        public const string palRes = "si|mientras|para|leer|imp|log";
        public const string TipDat = "ent|cad|dec";
        public const string dec = digito + "*[.]" + Num;
        public const string cad = "^\"$[" + digito + "|" + letra + "|" + OpLog + "|" + CarEsp + "|" + esp + "]*^\"$";
        public const string vari = "^(" + letra + "|_)[" + letra + "|" + digito + "|_]*$";
        public const string operacion = "(" + Num + "|" + dec + ")" + OpMat + "(" + Num + "|" + dec + "|" + ")";
        public const string consNum = "[[" + TipDat + "]=[" + Num + "|" + dec + "];]";

        Regex numero = new Regex(Num);
        Regex log = new Regex(OpLog);
        Regex rel = new Regex(OpRel);
        Regex uni = new Regex(OpUni);
        Regex car = new Regex(CarEsp);
        Regex cadena = new Regex(cad);
        Regex palabras = new Regex(palRes);
        Regex dat = new Regex(TipDat);
        Regex decim = new Regex(dec);
        Regex varib = new Regex(vari);
        Regex opera = new Regex(operacion);
        Regex constNum = new Regex(consNum);


        Regex pru = new Regex(OpMat);

        public string ConvertirToken(string token)
        {

            if (palabras.IsMatch(token))
            {
                return "palabra reservada";
            }

            if (constNum.IsMatch(token))
            {
                return "asignacion numero";
            }

            if (dat.IsMatch(token))
            {
                return "tipo de dato";
            }

            if (uni.IsMatch(token))
            {
                return "operador unitario";
            }

            if (opera.IsMatch(token))
            {
                return "operacion matematica";
            }

            if (pru.IsMatch(token))
            {
                return "operador matematico";
            }

            if (decim.IsMatch(token))
            {
                return "numero decimal";
            }

            if (numero.IsMatch(token))
            {
                return "numero";
            }

            if (rel.IsMatch(token))
            {
                return "operador relacional";
            }

            if (log.IsMatch(token))
            {
                return "operador logico";
            }

            if (car.IsMatch(token))
            {
                return "caracter especial";
            }

            if (varib.IsMatch(token))
            {
                return "variable";
            }

            if (cadena.IsMatch(token))
            {
                return "cadena";
            }
            return "no";
        }
    }
}

