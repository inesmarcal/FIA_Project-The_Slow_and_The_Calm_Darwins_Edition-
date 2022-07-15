//Amanda Oliveira de Menezes   2017124788    uc2017124788@student.uc.pt 
//Inês Martins Marçal      2019215917    uc2019215917@student.uc.pt 
//Noémia Quintano Mora Gonçalves  2019219433    uc2019219433@student.uc.pt

using GeneticSharp.Domain.Chromosomes;
using System;
using System.Linq;
using UnityEngine;
using GeneticSharp.Domain.Randomizations;
using System.Collections.Generic;
using GeneticSharp.Domain.Crossovers;

namespace GeneticSharp.Runner.UnityApp.Commons
{
    public class SinglePointCrossover : ICrossover
    {
  
        public int ParentsNumber { get; private set; }

        public int ChildrenNumber { get; private set; }

        public int MinChromosomeLength { get; private set; }

        public bool IsOrdered { get; private set; }     //Indica se um determinado operador se encontra ordenado (se a ordem dos cromossomas irá ser mantida).

        protected float crossoverProbability;


        public SinglePointCrossover(float crossoverProbability) : this(2, 2, 2, true)
        {
            this.crossoverProbability = crossoverProbability;
        }

        public SinglePointCrossover(int parentsNumber, int offSpringNumber, int minChromosomeLength, bool isOrdered)
        {
            ParentsNumber = parentsNumber;
            ChildrenNumber = offSpringNumber;
            MinChromosomeLength = minChromosomeLength;
            IsOrdered = isOrdered;
        }

        //O método tem como parâmetro a lista de progenitores ( obtida quando foram escolhidos os indivíduos mais aptos para a geração seguinte)
        public IList<IChromosome> Cross(IList<IChromosome> parents)
        {
            //Progenitor 1
            IChromosome parent1 = parents[0];
            //Progenitor 2
            IChromosome parent2 = parents[1];
            //Filho 1 inicializado com o Progenitor 1
            IChromosome offspring1 = parent1.CreateNew();
            //Filho 2 inicializado com o Progenitor 2
            IChromosome offspring2 = parent2.CreateNew();
            int cutPoint;

            int i = 0;
            
            if(RandomizationProvider.Current.GetDouble() <= crossoverProbability){
                //Definir o cutPoint, é selecionado um ponto de forma aleatória em cada progenitor, que posteriormente é definido
                //como sendo o ponto de recombinação 
                cutPoint = RandomizationProvider.Current.GetInt(1, parent1.Length);
                while(i < cutPoint){
                    //até ao cutPoint o filho 1 recebe os genes do parent2, sendo que foi inicializado com uma copia do parent 1 
                    offspring1.ReplaceGene(i, parent2.GetGene(i));
                    //até ao cutPoint o filho 2 recebe os genes do parent1, sendo que foi inicializado com uma copia do parent 2
                    offspring2.ReplaceGene(i, parent1.GetGene(i));
                    i++;
                }
            }

            //É retornada a lista de descendentes obtida através de recombinação
            return new List<IChromosome> { offspring1, offspring2 };
            
        }
    }
}