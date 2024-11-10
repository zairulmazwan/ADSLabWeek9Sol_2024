public class HillClimbing
{
    public static List<Double> data;
    public HillClimbing(List<Double> d)
    {
        data = new List<double>(d);
    }

    public void runHC(int iter)
    {
        double [,] result = new double[iter,3];
        List<List<int>> solutions = new List<List<int>>();

        // Create a new solution
        Scales solution = new Scales();
        Scales newSol = new Scales();
        // copy the existion solution to the new solution
        newSol.copySolution(solution.solution);
        // Start searching a solution
        for (int i = 0; i<iter; i++)
        {   
            result[i,0] = i;
            result[i,1] = solution.fitness;
            result[i,2] = newSol.fitness;
            solutions.Add(solution.solution);

            // perform a small change toward the new solution
            newSol = smallChange(newSol,3);
            Console.WriteLine("Iter "+(i+1));
            Console.WriteLine("Solution Fitness "+solution.fitness);
            solution.printSol();
            Console.WriteLine("New Solution Fitness "+newSol.fitness);
            newSol.printSol();

            // If tne new solution is better than the current solution, we copy the solution from the new one
            if (newSol.fitness<solution.fitness)
            {
                solution.copySolution(newSol.solution);
            }
        }
            Console.WriteLine("Final solution "+solution.fitness);
            ReadWriteFile.writeResults(result, "result.csv");
            ReadWriteFile.writeSolutions(solutions, "solutions.csv");
    }

    public Scales smallChange(Scales newSol, int n)
    {
        Random r = new Random();
        for(int i=0; i<n; i++)    
        {
            int a = r.Next(2);
            if(newSol.solution[a]==0)
                newSol.solution[a] = 1;
            else    
                newSol.solution[a] = 0;        }
        newSol.calculateFitness();
        return newSol;
    }
}