//Amanda Oliveira de Menezes   2017124788    uc2017124788@student.uc.pt 
//Inês Martins Marçal      2019215917    uc2019215917@student.uc.pt 
//Noémia Quintano Mora Gonçalves  2019219433    uc2019219433@student.uc.pt

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Runner.UnityApp.Car;

public class Tournament : SelectionBase
{
    protected int Size { get; set; }
    public Tournament() : this(2)
    {
    }

    public Tournament(int size) : base(2)
    {
        Size = size;
    }

    //Permite selecionar Size indivíduos que posteriormente serão adicionados à lista de progenitores da próxima geração
    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {

        //População atual: de onde irão ser selecionados os indivíduos mais aptos para a geração seguinte
        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList(); 
        //Lista de parentes devolvida e que contém os progenitores das próximas gerações com as melhores caraterísticas
        IList<IChromosome> parents = new List<IChromosome>(); 
        int i = 0;
        int k = 0;
        int individualIndex;
        int[] randomIndexes;
        CarChromosome winner;
        float winnerFitness;

        while(i < number){      
            //É escolhido size (número de elementos definido para o torneio) índices que vai de 0 ao número máximo de indivíduos da população
            randomIndexes = RandomizationProvider.Current.GetUniqueInts(Size, 0, population.Count);
            winner = null;
            winnerFitness = -1 ;
            k = 0;
            //Serão percorridos todos os índices aleatórios gerados em cima, ou seja tantos índices quanto o número definido para o torneio
            while(k < Size){   
                individualIndex = randomIndexes[k];
                //Ver qual dos 5 tem melhor fitness
                if ((winner == null) || population[individualIndex].Fitness > winnerFitness){
                    winner = population[individualIndex];
                    winnerFitness = population[individualIndex].Fitness;
                } 
                k++;
                //progenitores das próximas gerações com as melhores caraterísticas e que as irão transmitir aos descendentes
                //por recombinação genética
                parents.Add(winner);

                        
            }
            i++;
        
    }
        return parents;
    }
    
}
