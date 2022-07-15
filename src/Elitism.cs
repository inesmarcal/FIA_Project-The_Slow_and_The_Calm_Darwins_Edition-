//Amanda Oliveira de Menezes   2017124788    uc2017124788@student.uc.pt 
//Inês Martins Marçal      2019215917    uc2019215917@student.uc.pt 
//Noémia Quintano Mora Gonçalves  2019219433    uc2019219433@student.uc.pt

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Reinsertions;


public class Elitism : ReinsertionBase
{
    protected int eliteSize = 0;
    public Elitism(int eliteSize) : base(false, false)
    {
        this.eliteSize = eliteSize;
    }
    
    //Tendo em conta o tamanho de elitismo pretendido, o método recebe como parâmetro a população, a lista de cromossomas que irão ser descendentes
    //e ainda a lista de progenitores da geração atual
    //O elitismo, que permite que um determinado número dos indivíduos seja passado à geração seguinte inalterados.
    protected override IList<IChromosome> PerformSelectChromosomes(IPopulation population, IList<IChromosome> offspring, IList<IChromosome> parents)
    {
        //A população é ordenada por ordem decrescente de fitness, aparecendo em primeiro os de maior fitness e por isso mais aptos ao problema
        var old_population = population.CurrentGeneration.Chromosomes.OrderByDescending(p => p.Fitness).ToList(); 
        int i = 0;
        //Definir os indivíduos que permanecerão inalterados para a geração seguinte
        while(i < eliteSize){
            //Na lista de descendentes são substituidos tantos indivíduos quanto o número definido para o elitismo.
            //Estes serão assim substituidos pelos indivíduos escolhidos para permanecerem inalterados
            offspring[i] = old_population[i];
            i++;
        }
        
        return offspring;
    }
    
}
