using IDEXlan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEXlan.Analizer
{
    public class SyntacticAnalizer
    {
        public string Code { get; set; }
        public SyntacticAnalizer(string code)
        {
            Code = code;
        }

        public List<ErrorTableModel> Analize()
        {
            //Esto es un comentario
            List<ErrorTableModel> error = new List<ErrorTableModel>();
            string[] lineas = Code.Split('\r');
            int numPyC = 0;
            for (int i = 0; i < lineas.Length; i++)
            {
                foreach(char c in lineas[i])
                {
                    if(c == ';')
                    {
                        numPyC++;
                    }
                }
                if (numPyC > 1)
                    error.Add(new ErrorTableModel { Line = i+1, Error = "No puede haber mas de un ';' en una linea"  });
                else
                    if (!(lineas[i][lineas[i].Length-1] == ';'))
                    error.Add(new ErrorTableModel { Line = i + 1, Error = "Error: Se esperaba ';'" });
                numPyC = 0;
            }
            return error;
        }
    }
}
