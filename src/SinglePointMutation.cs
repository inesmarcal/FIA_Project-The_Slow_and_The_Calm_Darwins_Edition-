//Amanda Oliveira de Menezes   2017124788    uc2017124788@student.uc.pt 
//Inês Martins Marçal      2019215917    uc2019215917@student.uc.pt 
//Noémia Quintano Mora Gonçalves  2019219433    uc2019219433@student.uc.pt

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Randomizations;

public class SinglePointMutation : IMutation
{
    //Variável que indica se um determinado operador se encontra ordenado (se a ordem dos cromossomas irá ser mantida)
    public bool IsOrdered { get; private set; } // indicating whether the operator is ordered (if can keep the chromosome order).

    public SinglePointMutation()
    {
        IsOrdered = true;
    }

    //O método recebe como parâmetros o cromossoma a ser mutado assim como a probabilidade de mutação
    public void Mutate(IChromosome chromosome, float probability)
        {
            int i = 0;
            while( i < chromosome.Length)
            {
                //A probabilidade de a mutação ocorrer irá depender da probabilidade de mutação definida
                if (RandomizationProvider.Current.GetDouble()<= probability)
                {
                    //O cromossoma é mutado
                    object geneValue = chromosome.GetGene(i).Value;
                    if ((int) geneValue == 1)
                    {
                        chromosome.ReplaceGene(i, new Gene(0));
                    }
                    else
                    {
                        chromosome.ReplaceGene(i, new Gene(1));
                    }
                    
                }
                i += 1;
            }
        
            
        }

}
