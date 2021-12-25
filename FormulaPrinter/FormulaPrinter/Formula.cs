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

        public string Print(float startX, float incX, int iX, IncrementType incTypeX, float startY, float incY, int iY, IncrementType incTypeY)
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
                y = Increment(y, incY, incTypeY);
            }

            sb.Append("\n\n");
            y = startY;

            for (i = 0; i < iX; i++)
            {
                sb.Append(string.Format($"{x:00.000}") + "  |");

                for (j = 0; j < iY; j++)
                {
                    sb.Append(Calculate(x, y) + "  ");
                    y = Increment(y, incY, incTypeY);
                }

                sb.Append("\n");
                y = startY;
                x = Increment(x, incX, incTypeX);
            }

            return sb.ToString();
        }

        private float Increment(float val, float inc, IncrementType incType)
        {
            switch(incType)
            {
                case IncrementType.Linear:
                    return val += inc;
                case IncrementType.Exponential:
                    return val *= inc;
            }

            return val;
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

    public enum IncrementType
    {
        Linear,
        Exponential
    }
}
