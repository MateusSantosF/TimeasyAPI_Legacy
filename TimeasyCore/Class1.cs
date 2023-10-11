
using System;
using TimeasyCore.src.Mock;
using TimeasyCore.src.Models;

namespace TimeasyCore
{
    public class Class1
    {

        private const int MAX_INTERATION = 1000;

        public static void Main(string[] args)
        {
            Timetable timetable = MockGenerator.GenarateFakeTimetableConfig(32);

            Console.Write(timetable);

        }

        public void GenerateSolution()
        {

            int seed = 42;
            Timetable timetable = MockGenerator.GenarateFakeTimetableConfig(seed);

            // gera horario semanal base com slots validos
            // gera solução inicial (si)
            // bestSolutionPoints = si.points

            for (int i = 0; i < MAX_INTERATION; i++)
            {

                // gera uma segunda solução inicial usando GRASP
                // Melhora a solução inicial utilizando de movimentos + busca tabu 

                // compara  solução candidata com a solução global
                // se melhor que global, atualiza e vai pra proxima iteração

            }
        }

        public void GreeadySolution()
        {

            // return initialValidSolution
        }
    }
}