namespace SimulazionePartitaCalcioDifficile
{
    internal class Program
    {
        

        static void CaloPuntiGiocatore(int[] squadra, int puntiDaSottrarre)
        {
            for (int i = 0; i < squadra.Length; i++)
            {
                if (squadra[i] - puntiDaSottrarre < 0)
                {
                    squadra[i] = 0;
                }
                else
                {
                    squadra[i] -= puntiDaSottrarre;
                }
            }
        }
        static void RossoDiretto(int[] squadra, string nomeSquadra)
        {
            Random random = new Random();
            // Scegliamo un giocatore a caso tra gli 11
            int giocatoreScelto = random.Next(0, 11);

            // Controlliamo che non sia già fuori (potenza già a 0)
            if (squadra[giocatoreScelto] > 0)
            {
                squadra[giocatoreScelto] = 0; // Il giocatore viene rimosso dal gioco
                Console.WriteLine("!!! FALLACCIO !!!");
                Console.WriteLine("ROSSO DIRETTO per il giocatore " + giocatoreScelto + " della SQUADRA " + nomeSquadra);
            }
        }
        static void Sostituzioni(int[] squadra, int[] panchinari, ref int contatoreCambi)
        {
            if (contatoreCambi >= 5)
            {
                Console.WriteLine("Non sono più possibili sostituzioni");
            }

            Random random = new Random();
            int posizioneTitolare = random.Next(0, 11);
            int posizionePanchina = random.Next(0, 5);

            int valoreTemporaneo = squadra[posizioneTitolare];
            squadra[posizioneTitolare] = panchinari[posizionePanchina];
            panchinari[posizionePanchina] = valoreTemporaneo;

            contatoreCambi++;
        }

        static void incremetoPuntiGiocatore(int[] squadra, int puntiDaAggiungere)
        {
            for (int i = 0; i < squadra.Length; i++)
            {
                if (squadra[i] > 0)
                {
                    squadra[i] += puntiDaAggiungere;
                }
            }
        }

        static int Somma(int[] squadra)
        {
            int somma = 0;
            for (int i = 0; i < squadra.Length; i++)
            {
                somma = squadra[i] + somma;
            }
            return somma;
        }

        static void ValorizzazioneTitolari(int[] squadra)
        {
            Random random = new Random();
            for (int i = 0; i < squadra.Length; i++)
            {
                squadra[i] = random.Next(30, 100);
            }
        }

        static void ValorizzazionePanchinari(int[] panchinari)
        {
            Random random = new Random();
            for (int i = 0; i < panchinari.Length; i++)
            {
                panchinari[i] = random.Next(1, 50);
            }
        }

        static void stampaGiocatori(int[] squadra)
        {
            for (int i = 0; i < squadra.Length; i++)
            {
                Console.WriteLine("il giocatore " + i + " ha come punteggio " + squadra[i]);
            }
        }

        static void stampaGiocatoriPanchinari(int[] panchinari)
        {
            for (int i = 0; i < panchinari.Length; i++)
            {
                Console.WriteLine("il giocatore in panchina " + i + " ha come punteggio " + panchinari[i]);
            }
        }

        static void Main(string[] args)
        {
            int[] squadraA = new int[11], squadraB = new int[11], panchinariA = new int[5], panchinariB = new int[5];
            int[] ammonizioniA = new int[11], ammonizioniB = new int[11];
            int cambiA = 0, cambiB = 0;

            Console.WriteLine("SQUADRA 1");
            ValorizzazioneTitolari(squadraA);
            ValorizzazionePanchinari(panchinariA);
            stampaGiocatori(squadraA);
            stampaGiocatoriPanchinari(panchinariA);

            Console.WriteLine("SQUADRA 2");
            ValorizzazioneTitolari(squadraB);
            ValorizzazionePanchinari(panchinariB);
            stampaGiocatori(squadraB);
            stampaGiocatoriPanchinari(panchinariB);

            int golSquadra = 0;
            int punteggioFinaleA = 0;
            int punteggioFinaleB = 0;
            int recupero = 0;
            int eventi = 0;

            Random random = new Random();
            for (int minuti = 0; minuti < 90 + recupero; minuti++)
            {
                int sommaSquadraA = Somma(squadraA);
                int sommaSquadraB = Somma(squadraB);
                int sommaTot = sommaSquadraA + sommaSquadraB;

                int eventoNullo = random.Next(0, 100);

                // Se succede qualcosa 
                if (eventoNullo < 50)
                {
                    eventi = random.Next(0, 100);

                    if (eventi < 8)
                    {
                        golSquadra = random.Next(0, sommaTot);
                        if (golSquadra <= sommaSquadraA)
                        {
                            Console.WriteLine("HA SEGNATO LA SQUADRA A");
                            punteggioFinaleA++;
                            incremetoPuntiGiocatore(squadraA, 3);
                        }
                        else
                        {
                            Console.WriteLine("HA SEGNATO LA SQUADRA B");
                            punteggioFinaleB++;
                            incremetoPuntiGiocatore(squadraB, 3);
                        }
                        if (minuti == 89)
                        {
                            recupero = random.Next(1, 5);
                        }
                    }
                    else if (eventi <= 25)
                    {
                        int giocatoreScelto = random.Next(0, 11);
                        if (random.Next(0, 2) == 0)
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("IL GIOCATORE " + giocatoreScelto + " DELLA SQUADRA A E' STATO AMMONITO");
                            ammonizioniA[giocatoreScelto]++;
                            if (ammonizioniA[giocatoreScelto] >= 2)
                            {
                                Console.WriteLine("IL GIOCATORE " + giocatoreScelto + " DELLA SQUADRA A E' STATO ESPULSO PER DOPPIA AMMONIZIONE");
                                squadraA[giocatoreScelto] = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("IL GIOCATORE " + giocatoreScelto + " DELLA SQUADRA B E' STATO AMMONITO");
                            ammonizioniB[giocatoreScelto]++;
                            if (ammonizioniB[giocatoreScelto] >= 2)
                            {
                                Console.WriteLine("IL GIOCATORE " + giocatoreScelto + " DELLA SQUADRA B E' STATO ESPULSO PER DOPPIA AMMONIZIONE");
                                squadraB[giocatoreScelto] = 0;
                            }
                        }
                    }
                    else if (eventi <= 60)
                    {
                        if (random.Next(0, 2) == 0)
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("LA SQUADRA A EFFETTUA UNA SOSTITUZIONE");
                            Sostituzioni(squadraA, panchinariA, ref cambiA);
                        }
                        else
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("LA SQUADRA B EFFETTUA UNA SOSTITUZIONE");
                            Sostituzioni(squadraB, panchinariB, ref cambiB);
                        }
                    }
                    else if (eventi == 1 )
                    {
                        if (random.Next(0, 2) == 0)
                        {
                            RossoDiretto(squadraA, "A");
                        }
                        else
                        {
                            RossoDiretto(squadraB, "B");
                        }
                    }
                    else
                    {
                        if (random.Next(0, 2) == 0)// se succede un calo di punti
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("CALO PUNTI PER LA SQUADRA A");
                            CaloPuntiGiocatore(squadraA, 15);
                        }
                        else
                        {
                            Console.WriteLine("MINUTO " + (minuti + 1));
                            Console.WriteLine("CALO PUNTI PER LA SQUADRA B");
                            CaloPuntiGiocatore(squadraB, 15);
                        }
                    }
                }               
                else
                {
                    Console.WriteLine("AL MINUTO " + (minuti + 1) + " NON E' SUCCESSO NIENTE");
                }
            }
            Console.WriteLine("IL RISULTATO FINALE E' " + punteggioFinaleA + " - " + punteggioFinaleB);
            Console.ReadLine();
        }
    }
}