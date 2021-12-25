using System;
using System.Text;

namespace FormulaPrinter
{
    public class Formula
    {
        private Func<float, float, float> formula;

        public Formula(Func<float, float, float> formula)
        {
            this.formula = formula;
        }

        public string Print(float startX, float incX, int iX, float startY, float incY, int iY)
        {
            var sb = new StringBuilder();

            float x = startX;
            float y = startY;

            int i = 0;
            int j = 0;

            sb.Append("X\\Y     |");
            for (j = 0; j < iY; j++)
            {
                sb.Append(string.Format($"{y:00.000}") + "  ");
                y += incY;
            }

            sb.Append("\n\n");
            y = startY;

            for (i = 0; i < iX; i++)
            {
                sb.Append(string.Format($"{x:00.000}") + "  |");

                for (j = 0; j < iY; j++)
                {
                    sb.Append(Calculate(x, y) + "  ");
                    y += incY;
                }

                sb.Append("\n");
                y = startY;
                x += incX;
            }

            return sb.ToString();
        }

        private string Calculate(float x, float y)
        {
            string ans = "ERR";

            try
            {
                ans = string.Format($"{formula.Invoke(x, y):00.000}");
            }
            catch (Exception)
            {
                // Ignore math errors.
            }

            return ans;
        }
    }
}
