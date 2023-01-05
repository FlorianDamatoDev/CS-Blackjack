namespace Blackjack {
    class Program {
        static void Main(string[] args) {
            int bankroll = 1000;
            char replay ='o';
            Console.Clear();

            // Accueil
            Console.WriteLine("");
            Console.WriteLine("          ██████╗ ██╗      █████╗  ██████╗██╗  ██╗         ██╗ █████╗  ██████╗██╗  ██╗");
            Console.WriteLine("          ██╔══██╗██║     ██╔══██╗██╔════╝██║ ██╔╝         ██║██╔══██╗██╔════╝██║ ██╔╝");
            Console.WriteLine("          ██████╔╝██║     ███████║██║     █████╔╝          ██║███████║██║     █████╔╝ ");
            Console.WriteLine("          ██╔══██╗██║     ██╔══██║██║     ██╔═██╗     ██   ██║██╔══██║██║     ██╔═██╗ ");
            Console.WriteLine("          ██████╔╝███████╗██║  ██║╚██████╗██║  ██╗    ╚█████╔╝██║  ██║╚██████╗██║  ██╗");
            Console.WriteLine("          ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝     ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          Appuyez sur une touche pour jouer...");
            Console.ResetColor();
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            do {
                bool bj = false;

                // Demande de la mise du joueur
                int bet = 0;
                Console.Clear();
                while (bet == 0 || bet > bankroll) {
                    Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                      "\n" + "          \u2551      Bankroll      \u2551" +
                                      "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551      " + bankroll);
                    Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");
                    Console.WriteLine("\n");
                    Console.WriteLine("\nEntrez votre mise :");
                    bet = int.Parse(Console.ReadLine());
                }

                // Création du deck et mélange des cartes
                List<Card> deck = CreateDeck();
                ShuffleDeck(deck);

                // Distribution des cartes aux joueurs
                List<Card> playerHand = new List<Card>();
                playerHand.Add(deck[0]);
                deck.RemoveAt(0);
                playerHand.Add(deck[0]);
                deck.RemoveAt(0);

                List<Card> dealerHand = new List<Card>();
                dealerHand.Add(deck[0]);
                deck.RemoveAt(0);
                dealerHand.Add(deck[0]);
                deck.RemoveAt(0);

                Console.Clear();

                // Affichage de la main du croupier
                Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                  "\n" + "          \u2551  Main du croupier  \u2551" +
                                  "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                Console.WriteLine("          \u2551   " + dealerHand[0].ToString());
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("          \u2551        ???");
                Console.ResetColor();
                Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                Console.WriteLine("          \u2551     Total : " + GetFirstHandDealer(dealerHand).ToString("D2") + "     \u2551");
                Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                // Affichage de la main du joueur
                Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                  "\n" + "          \u2551     Votre main     \u2551" +
                                  "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                foreach (Card card in playerHand) { Console.WriteLine("          \u2551   " + card.ToString()); }
                Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                Console.WriteLine("          \u2551     Total : " + GetHandTotal(playerHand).ToString("D2") + "     \u2551");
                Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                if (GetHandTotal(playerHand) == 21) {
                    bj = true;
                    goto blackjack;
                }

                // Demande au joueur s'il veut une carte supplémentaire
                Console.WriteLine("\n");
                Console.WriteLine("\nVoulez-vous une carte supplémentaire (o/n) ?");
                char input = char.Parse(Console.ReadLine());
                while (input == 'o' && GetHandTotal(playerHand) <= 21) {
                    playerHand.Add(deck[0]);
                    deck.RemoveAt(0);
                    Console.Clear();

                    // Affichage de la main du croupier
                    Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                      "\n" + "          \u2551  Main du croupier  \u2551" +
                                      "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551   " + dealerHand[0].ToString());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("          \u2551        ???");
                    Console.ResetColor();
                    Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551     Total : " + GetFirstHandDealer(dealerHand).ToString("D2") + "     \u2551");
                    Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                    //Affichage de la main du joueur
                    Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                      "\n" + "          \u2551     Votre main     \u2551" +
                                      "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    int l = 0;
                    foreach (Card card in playerHand) {
                        if (l == 0 || l == 1) {
                            Console.WriteLine("          \u2551   " + card.ToString());
                        } else {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("          \u2551   " + card.ToString());
                            Console.ResetColor();
                        }
                        l++;
                    }
                    Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551     Total : " + GetHandTotal(playerHand).ToString("D2") + "     \u2551");
                    Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                    if (GetHandTotal(playerHand) < 21) {
                        Console.WriteLine("\n");
                        Console.WriteLine("\nVoulez-vous une carte supplémentaire (o/n) ?");
                        input = char.Parse(Console.ReadLine());
                    }
                }

                // Tour du croupier
                while (GetHandTotal(dealerHand) < 17) {
                    dealerHand.Add(deck[0]);
                    deck.RemoveAt(0);
                    Console.Clear();

                    // Affichage de la main du croupier
                    Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                      "\n" + "          \u2551  Main du croupier  \u2551" +
                                      "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    int m = 0;
                    foreach (Card card in dealerHand) {
                        if (m == 0) {
                            Console.WriteLine("          \u2551   " + card.ToString());
                        } else {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("          \u2551   " + card.ToString());
                            Console.ResetColor();
                        }
                        m++;
                    }
                    Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551     Total : " + GetHandTotal(dealerHand).ToString("D2") + "     \u2551");
                    Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                    // Affichage de la main du joueur
                    Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                      "\n" + "          \u2551     Votre main     \u2551" +
                                      "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    foreach (Card card in playerHand) { Console.WriteLine("          \u2551   " + card.ToString()); }
                    Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                    Console.WriteLine("          \u2551     Total : " + GetHandTotal(playerHand).ToString("D2") + "     \u2551");
                    Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                    System.Threading.Thread.Sleep(700);
                }

                // Affichage Résultat
                Console.Clear();
                //
                Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                  "\n" + "          \u2551  Main du croupier  \u2551" +
                                  "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                int n = 0;
                foreach (Card card in dealerHand) {
                    if (n == 0) {
                        Console.WriteLine("          \u2551   " + card.ToString());
                    } else {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("          \u2551   " + card.ToString());
                        Console.ResetColor();
                    }
                    n++;
                }
                Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                Console.WriteLine("          \u2551     Total : " + GetHandTotal(dealerHand).ToString("D2") + "     \u2551");
                Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");
                //
                Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                  "\n" + "          \u2551     Votre main     \u2551" +
                                  "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                foreach (Card card in playerHand) { Console.WriteLine("          \u2551   " + card.ToString()); }
                Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                Console.WriteLine("          \u2551     Total : " + GetHandTotal(playerHand).ToString("D2") + "     \u2551");
                Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                // Détermination du gagnant
                if (GetHandTotal(playerHand) > 21) {
                    bankroll = bankroll - bet;
                    Console.WriteLine("\nPERDU ! Bankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                    replay = char.Parse(Console.ReadLine());
                } else if (GetHandTotal(dealerHand) > 21) {
                    bankroll = bankroll + bet;
                    Console.WriteLine("\nGAGNÉ ! Bankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                    replay = char.Parse(Console.ReadLine());
                } else if (GetHandTotal(playerHand) > GetHandTotal(dealerHand)) {
                    bankroll = bankroll + bet;
                    Console.WriteLine("\nGAGNÉ ! Bankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                    replay = char.Parse(Console.ReadLine());
                } else if (GetHandTotal(playerHand) < GetHandTotal(dealerHand)) {
                    bankroll = bankroll - bet;
                    Console.WriteLine("\nPERDU ! Bankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                    replay = char.Parse(Console.ReadLine());
                } else {
                    Console.WriteLine("\nÉGALITÉ ! Bankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                    replay = char.Parse(Console.ReadLine());
                }
                blackjack:
                    if (bj == true) {
                        Console.Clear();

                        // Affichage de la main du croupier
                        Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                          "\n" + "          \u2551  Main du croupier  \u2551" +
                                          "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                        foreach (Card card in dealerHand) { Console.WriteLine("          \u2551   " + card.ToString()); }
                        Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                        Console.WriteLine("          \u2551     Total : " + GetHandTotal(dealerHand).ToString("D2") + "     \u2551");
                        Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");
                    
                        // Affichage de la main du joueur
                        Console.WriteLine("\n" + "          \u2554\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2557" +
                                          "\n" + "          \u2551     Votre main     \u2551" +
                                          "\n" + "          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                        foreach (Card card in playerHand) { Console.WriteLine("          \u2551   " + card.ToString()); }
                        Console.WriteLine("          \u2560\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2563");
                        Console.WriteLine("          \u2551     Total : " + GetHandTotal(playerHand).ToString("D2") + "     \u2551");
                        Console.WriteLine("          \u255a\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u255d");

                        if (GetHandTotal(dealerHand) == 21) {
                            Console.WriteLine("\nLe croupier à aussi BlackJack... ÉGALITÉ !");
                            Console.WriteLine("\nBankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                            replay = char.Parse(Console.ReadLine());
                        } else {
                            Console.WriteLine("");
                            Console.WriteLine("          ██████╗ ██╗      █████╗  ██████╗██╗  ██╗         ██╗ █████╗  ██████╗██╗  ██╗    ██╗");
                            Console.WriteLine("          ██╔══██╗██║     ██╔══██╗██╔════╝██║ ██╔╝         ██║██╔══██╗██╔════╝██║ ██╔╝    ██║");
                            Console.WriteLine("          ██████╔╝██║     ███████║██║     █████╔╝          ██║███████║██║     █████╔╝     ██║");
                            Console.WriteLine("          ██╔══██╗██║     ██╔══██║██║     ██╔═██╗     ██   ██║██╔══██║██║     ██╔═██╗     ╚═╝");
                            Console.WriteLine("          ██████╔╝███████╗██║  ██║╚██████╗██║  ██╗    ╚█████╔╝██║  ██║╚██████╗██║  ██╗    ██╗");
                            Console.WriteLine("          ╚═════╝ ╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝     ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝    ╚═╝");
                            Console.WriteLine("");

                            double coefBJ = 1.5;
                            int benef = (int)Math.Round(bet * coefBJ);
                            bankroll = bankroll + benef;
                            Console.WriteLine("\nBankroll : " + bankroll + "\u20AC ! Rejouer (o/n) ?");
                            replay = char.Parse(Console.ReadLine());
                        }
                    }
            } while (replay == 'o');
        }

        static List<Card> CreateDeck() {

            // Création de chaque carte et ajout dans le deck
            List<Card> deck = new List<Card>();
            foreach (Suit s in Enum.GetValues(typeof(Suit))) {
                foreach (Value v in Enum.GetValues(typeof(Value))) {
                    deck.Add(new Card(s, v));
                }
            }
            return deck;
        }

        static void ShuffleDeck(List<Card> deck) {
            Random rng = new Random();

            // Mélange du deck
            int n = deck.Count;
            while (n > 1) {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        static int GetHandTotal(List<Card> hand) {
            int total = 0;
            int aces = 0;

            // Calcul du total de la main
            foreach (Card card in hand) {
                if (card.Value == Value.As) {
                    aces++;
                }
                if ((int)card.Value == 12) { // Valet = 10
                    total -= 2;
                }
                if ((int)card.Value == 13) { // Dame = 10
                    total -= 3;
                }
                if ((int)card.Value == 14) { // Roi = 10
                    total -= 4;
                }
                total += (int)card.Value;
            }

            // Gestion des as
            while (total > 21 && aces > 0) {
                total -= 10;
                aces--;
            }

            return total;
        }

        static int GetFirstHandDealer(List<Card> hand) {
            int total = 0;
            int aces = 0;

            // Calcul de la main de base du dealer -> exeptions buches
            foreach (Card card in hand) {
                if (card.Value == Value.As) {
                    aces++;
                }
                if ((int)card.Value == 12) { // Valet = 10
                    total -= 2;
                }
                if ((int)card.Value == 13) { // Dame = 10
                    total -= 3;
                }
                if ((int)card.Value == 14) { // Roi = 10
                    total -= 4;
                }
                total += (int)card.Value;
                break;
            }

            // Gestion des as
            while (total > 21 && aces > 0) {
                total -= 10;
                aces--;
            }

            return total;
        }
    }

    class Card {
        public Suit Suit { get; set; }
        public Value Value { get; set; }

        public Card(Suit suit, Value value) {
            Suit = suit;
            Value = value;
        }

        public override string ToString() {
            return Value.ToString() + " de " + Suit.ToString();
        }
    }

    enum Suit {
        Trèfle,
        Carreau,
        Coeur,
        Pique
    }

    enum Value {
        Deux = 2,
        Trois = 3,
        Quatre = 4,
        Cinq = 5,
        Six = 6,
        Sept = 7,
        Huit = 8,
        Neuf = 9,
        Dix = 10,
        Valet = 12,
        Dame = 13,
        Roi = 14,
        As = 11
    }
}