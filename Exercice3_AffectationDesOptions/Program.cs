using System;
using System.Collections.Generic;

namespace Exercice_affectation_des_options_de_la_filière_informatique_aux_étudiants

{
    class Program
    {
        static void Main(string[] args)

        {
            //création des options ( GL - ABD - ASR ) :

            Console.WriteLine("Veuillez entrer le nombre des places disponibles dans chaque option :");

            Option GL = new Option();
            GL.typeOption = "GL";
            Console.Write("\nles places disponibles dans GL :\t");
            GL.PlacesDisponibles = Convert.ToInt32(Console.ReadLine());

            Option ABD = new Option();
            ABD.typeOption = "ABD";
            Console.Write("les places disponibles dans ABD :\t");
            ABD.PlacesDisponibles = Convert.ToInt32(Console.ReadLine());

            Option ASR = new Option();
            ASR.typeOption = "ASR";
            Console.Write("les places disponibles dans ASR :\t");
            ASR.PlacesDisponibles = Convert.ToInt32(Console.ReadLine());

            int nbrEtudiants = GL.PlacesDisponibles + ABD.PlacesDisponibles + ASR.PlacesDisponibles;

            //---------------------------------------------------------------------
            //creer une liste des tuples contenant les etudiants et leurs choix
            List<Tuple<Etudiant, string, string, string>> listEt = new List<Tuple<Etudiant, string, string, string>>();


            //entrer les etudiants et leurs choix

            Console.WriteLine("Veuillez entrez les informations de chaque étudiant :");

            for (int i = 0; i < nbrEtudiants; i++)
            {
                Console.WriteLine("\nEtudiant N° " + (i+1) + ":");
                Console.Write("\nNom Complet de l'etudiant:\t");
                string Nom = Console.ReadLine();
                Console.Write("\nLa note de 1ère année :\t");
                float Note = float.Parse(Console.ReadLine());
                Etudiant etudiant = new Etudiant(Nom, Note);

                Console.WriteLine("entrez les choix: (GL, ABD ou ASR)");

                Console.Write("\nLe 1er choix :\t");
                string choix1 = Console.ReadLine();
                Console.Write("\nLe 2ème choix :\t");
                string choix2 = Console.ReadLine();
                Console.Write("\nLe 3ème choix :\t");
                string choix3 = Console.ReadLine();


                var choix = Tuple.Create(etudiant, choix1, choix2, choix3);
                listEt.Add(choix);

                Console.WriteLine("--------------------------------------------------");

            }
            //triage de la liste des etudiants par ses notes:
            listEt.Sort((etudiant1, etudiant2) => etudiant2.Item1.Note.CompareTo(etudiant1.Item1.Note));

            //creer 3 listes des etudiants de 3 options pour l'affichage :
            var listEtGL = new List<Etudiant>();
            var listEtABD = new List<Etudiant>();
            var listEtASR = new List<Etudiant>();

            //traiter les cas des options
            for (int j = 0; j < nbrEtudiants; j++)
            {
                switch (listEt[j].Item2)
                {
                    case "GL":
                        if (GL.PlacesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[j].Item1;
                            listEtGL.Add(item1);
                            --GL.PlacesDisponibles;
                        }
                        else
                        {

                            switch (listEt[j].Item3)
                            {
                                case "ABD":
                                    if (ABD.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtABD.Add(item2);
                                        --ABD.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "ASR" && ASR.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtASR.Add(item3);
                                            --ASR.PlacesDisponibles;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (ASR.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtASR.Add(item2);
                                        --ASR.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "ABD" && ABD.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtABD.Add(item3);
                                            --ABD.PlacesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ABD":
                        if (ABD.PlacesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[j].Item1;
                            listEtABD.Add(item1);
                            --ABD.PlacesDisponibles;
                        }
                        else
                        {

                            switch (listEt[j].Item3)
                            {
                                case "GL":
                                    if (GL.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtGL.Add(item2);
                                        --GL.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "ASR" && ASR.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtASR.Add(item3);
                                            --ASR.PlacesDisponibles;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (ASR.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtASR.Add(item2);
                                        --ASR.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "GL" && GL.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtGL.Add(item3);
                                            --GL.PlacesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ASR":
                        if (ASR.PlacesDisponibles > 0)
                        {
                            Etudiant item1 = listEt[j].Item1;
                            listEtASR.Add(item1);
                            --ASR.PlacesDisponibles;
                        }
                        else
                        {

                            switch (listEt[j].Item3)
                            {
                                case "ABD":
                                    if (ABD.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtABD.Add(item2);
                                        --ABD.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "GL" && GL.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtGL.Add(item3);
                                            --GL.PlacesDisponibles;
                                        }
                                    }
                                    break;

                                case "GL":
                                    if (GL.PlacesDisponibles > 0)
                                    {
                                        Etudiant item2 = listEt[j].Item1;
                                        listEtGL.Add(item2);
                                        --GL.PlacesDisponibles;
                                    }
                                    else
                                    {
                                        if (listEt[j].Item4 == "ABD" && ABD.PlacesDisponibles > 0)
                                        {
                                            Etudiant item3 = listEt[j].Item1;
                                            listEtABD.Add(item3);
                                            --ABD.PlacesDisponibles;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                }

            }

            //affichage des étudiants admis à chaque liste :
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("la liste des étudiants attribués à la filière GL :");
            Console.WriteLine("---------------------------------------------------");

            foreach (Etudiant EtGL in listEtGL)
            {
                Console.WriteLine("\n\t"+EtGL.NomComplet + "\t | \t" + EtGL.Note);
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("la liste des étudiants attribués à la filière ABD :");
            Console.WriteLine("----------------------------------------------------");
            
            foreach (Etudiant EtABD in listEtABD)
            {
                Console.WriteLine("\n\t" + EtABD.NomComplet + "\t | \t" + EtABD.Note);
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("la liste des étudiants attribués à la filière ASR :");
            Console.WriteLine("----------------------------------------------------");

            foreach (Etudiant EtASR in listEtASR)
            {
                Console.WriteLine("\n\t" + EtASR.NomComplet + "\t | \t" + EtASR.Note);
            }
        }

    }
}

//Exercice: affectation des options de la filière informatique aux étudiants

/*1 - Modéliser et implémenter les associations suivantes:
-Un étudiant doit obligatoirement candidater pour les trois options de la filière informatiques avec l'ordre de préférence.
-A un étudiant est attribué une seule option selon l'ordre de mérite (note moyenne de la première année) et l'ordre de préférence qu'il a exprimer.
2 - Implémenter l'algorithme d'attribution des options aux étudiants (Version simple de l'algorithme de Gale et Shapley).

Livrables:
Lien cliquable vers votre repository GitHub content une image du diagramme de classes UML, les classes résultantes C# ainsi que l'implémentation de l'algorithme d'attribution des option.*/