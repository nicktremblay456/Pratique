namespace TNT
{
    /// <copyright file="SaisieSansFaille.cs">
    /// Copyright © 2022 © All Rights Reserved
    /// </copyright>
    /// <author>Nicolas Tremblay</author>
    /// <date>2022/01/22 16:26 PM </date>
    /// <summary>Class representing Saisie sans faille</summary>
    public class SaisieSansFaille
    {
        private int input;

        public void Process()
        {
            Console.WriteLine("Entrer un nombre entier entre 1 et 150");
            GetInput();

            while (input < 1 || input > 150)
            {
                GetInput();
            }
        }

        private void GetInput()
        {
            try { input = int.Parse(Console.ReadLine()); }
            catch { input = 0; }

            Console.WriteLine((input >= 1 && input <= 150) ? "ACCEPTER" : "REFUSER \nLa valeur entrée est invalide, entrer un nombre entier entre 1 et 150");
        }
    }
}