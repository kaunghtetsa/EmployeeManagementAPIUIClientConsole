using System;

namespace ASM.EmployeeManagementAPIUIClientConsole.Utility
{
    /// <summary>
    /// Common utilize methods
    /// </summary>
    public static class CommonUtil
    {
        #region Public methods

        /// <summary>
        /// Print Line
        /// </summary>
        public static void PrintLine(int width)
        {
            Console.WriteLine(new string('-', width));
        }

        /// <summary>
        /// Print Data Row
        /// </summary>
        /// <param name="tableWidth"></param>
        /// <param name="columns"></param>
        public static void PrintRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        #endregion

        #region Private method

        /// <summary>
        /// Align Center
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        #endregion
    }
}
