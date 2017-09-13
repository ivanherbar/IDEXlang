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
        public const string OpLog = "[\u0026 \u007C \u0026\u0026 \u007C\u007C !]"; // &, |, &&, ||
        public const string OpRel = "[<|>|=|>=|<=|==|!=]";
        public const string OpUni = "[++|--]";
        public const string esp = " ";
        public const string CarEsp = "[@|(|)|{|}|#|?|[|]]";
        public const string OpMat = "[\\+|-|\u002A|/|%|-]"; //+, -, *, %
        public const string Num = digito + "+";
        public const string palRes = "[si|mientras|para|leer|imp|ent|dec|cad|log]";
        public const string TipDat = "(ent|cad|dec|log)";
        public const string dec = digito + "*" + "." + Num;
        public const string cad = "\"(" + digito + "|" + letra + "|" + OpLog + "|" + CarEsp + "|" + esp + ")*\"";
        public const string vari = "[" + letra + "|_]" + "[" + letra + "|" + digito + "|" + "_]*";
        public const string operacion = "(" + Num + "|" + dec + ")" + OpMat + "(" + Num + "|" + dec + "|" + ")";
        public const string cons = "[[" + TipDat + "]" + "=[" + Num + "|" + dec + "];]";

        public string ConvertirToken(string token)
        {
            Regex rex = new Regex(OpMat);
            if (rex.IsMatch(token))
            {
                return "si";
            }
            return "no";
        }
    }
}
