using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YahtzeeProject
{
    public partial class MainPage : ContentPage
    {


        const int MAX_ROLLS = 3;

        Random random;

        int _TurnRoll;

        int[][] _SMALL_STRAIGHT;





        public MainPage()
        {
            InitializeComponent();

            _TurnRoll = 1;
            

        }



        private void BtnDiceRoll_Clicked(object sender, EventArgs e)
        {
            int dice1Roll;
            int dice2Roll;
            int dice3Roll;
            int dice4Roll;
            int dice5Roll;

            string ButtonText = ((Button)sender).Text;

            LblRollNumber.Text = "Roll Number " + _TurnRoll.ToString();

            if (random == null) random = new Random();

            dice1Roll = random.Next(1, 7);
            dice2Roll = random.Next(1, 7);
            dice3Roll = random.Next(1, 7);
            dice4Roll = random.Next(1, 7);
            dice5Roll = random.Next(1, 7);

            if (BtnDice1.StyleId == "Roll") BtnDice1.Text = dice1Roll.ToString();
            if (BtnDice2.StyleId == "Roll") BtnDice2.Text = dice2Roll.ToString();
            if (BtnDice3.StyleId == "Roll") BtnDice3.Text = dice3Roll.ToString();
            if (BtnDice4.StyleId == "Roll") BtnDice4.Text = dice4Roll.ToString();
            if (BtnDice5.StyleId == "Roll") BtnDice5.Text = dice5Roll.ToString();




            if (_TurnRoll == MAX_ROLLS)
            {
                _TurnRoll = 0;
                BtnDiceRoll.IsEnabled = false;
                LblRollNumber.Text = "Roll Number 3 - Pick your Score! ";
            }

            _TurnRoll++;

        }

        private void BtnDiceChosen_Clicked(Object sender, EventArgs e)
        {
            Button currentButton;

            currentButton = (Button)sender;
            if (currentButton.StyleId == "Roll")
            {
                currentButton.StyleId = "Hold";
                currentButton.BackgroundColor = Color.Red;
            }
            else
            {
                currentButton.StyleId = "Roll";
                currentButton.BackgroundColor = Color.White;
            }
        }




        private void BtnDiceScoresUpper_Clicked(object sender, EventArgs e)
        {

            Button currScore = (Button)sender;
            int total = 0;
            string numberValue = currScore.StyleId;

            if (BtnDice1.Text == numberValue) total += Convert.ToInt32(BtnDice1.Text);
            if (BtnDice2.Text == numberValue) total += Convert.ToInt32(BtnDice2.Text);
            if (BtnDice3.Text == numberValue) total += Convert.ToInt32(BtnDice3.Text);
            if (BtnDice4.Text == numberValue) total += Convert.ToInt32(BtnDice4.Text);
            if (BtnDice5.Text == numberValue) total += Convert.ToInt32(BtnDice5.Text);




            if (currScore.StyleId == "1")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }
            if (currScore.StyleId == "2")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }
            if (currScore.StyleId == "3")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }
            if (currScore.StyleId == "4")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }
            if (currScore.StyleId == "5")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }
            if (currScore.StyleId == "6")
            {
                currScore.ClassId = "locked";
                currScore.IsEnabled = false;
            }

            //string lblName = "Lbl" + numberValue;
            //Label UpdateThisLabel = (Label)FindByName(lblName);
            //UpdateThisLabel.Text = total.ToString();

            String updateLabel = "Lbl" + numberValue;
            Label UpdateThisLabel = (Label)FindByName(updateLabel);
            UpdateThisLabel.Text = total.ToString();


            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";


            if (currScore.StyleId == "locked")
            {
                BtnDiceRoll.IsEnabled = true;
            }
            totalUpScore();
            allButtonsClicked();


        }

        private int CheckThreeFourFiveKinds(int KindValue)
        {
            int HaveAKind = 0;
            int diceValue;

            int[] totalKindPerNumber = new int[6] { 0, 0, 0, 0, 0, 0 };



            diceValue = Convert.ToInt32(BtnDice1.Text); //Gets the number on the dice
            totalKindPerNumber[diceValue - 1]++; //reads dice value (- 1) to increment it in the array

            diceValue = Convert.ToInt32(BtnDice2.Text);
            totalKindPerNumber[diceValue - 1]++;

            diceValue = Convert.ToInt32(BtnDice3.Text);
            totalKindPerNumber[diceValue - 1]++;

            diceValue = Convert.ToInt32(BtnDice4.Text);
            totalKindPerNumber[diceValue - 1]++;

            diceValue = Convert.ToInt32(BtnDice5.Text);
            totalKindPerNumber[diceValue - 1]++;

            for (int i = 0; i < totalKindPerNumber.Length; i++)
            {
                if (totalKindPerNumber[i] >= KindValue)
                {
                    HaveAKind = 1;
                    i = totalKindPerNumber.Length; //breaks loop with new score value > 0
                }
            }

            return HaveAKind;

        }



        private void totalUpScore()
        {

            int totalUpValue = 0;

            if (Lbl1.Text != "") totalUpValue += Convert.ToInt32(Lbl1.Text);
            if (Lbl2.Text != "") totalUpValue += Convert.ToInt32(Lbl2.Text);
            if (Lbl3.Text != "") totalUpValue += Convert.ToInt32(Lbl3.Text);
            if (Lbl4.Text != "") totalUpValue += Convert.ToInt32(Lbl4.Text);
            if (Lbl5.Text != "") totalUpValue += Convert.ToInt32(Lbl5.Text);
            if (Lbl6.Text != "") totalUpValue += Convert.ToInt32(Lbl6.Text);


            if (totalUpValue >= 63)
            {
                totalUpValue = totalUpValue + 35;

                String updateLabel = "LblUpperBonus";
                Label l = (Label)FindByName(updateLabel);
                l.Text = "+35";

            }
            LblUpTotal.Text = totalUpValue.ToString();
        }

        private void totalLowScore()
        {
            int totalLowValue = 0;

            if (Lbl3oK.Text != "") totalLowValue += Convert.ToInt32(Lbl3oK.Text);
            if (Lbl4oK.Text != "") totalLowValue += Convert.ToInt32(Lbl4oK.Text);
            if (LblYahtzee.Text != "") totalLowValue += Convert.ToInt32(LblYahtzee.Text);
            if (Lbl4Row.Text != "") totalLowValue += Convert.ToInt32(Lbl4Row.Text);
            if (Lbl5Row.Text != "") totalLowValue += Convert.ToInt32(Lbl5Row.Text);
            if (LblChance.Text != "") totalLowValue += Convert.ToInt32(LblChance.Text);
            if (LblFullHouse.Text != "") totalLowValue += Convert.ToInt32(LblFullHouse.Text);

            LblLowTotal.Text = totalLowValue.ToString();

            //string lblName = "LblLowTotal";
            //Label UpdateThisLabel = (Label)FindByName(lblName);
            //UpdateThisLabel.Text = totalLowValue.ToString();
        }


        private void BtnThreeKind_Clicked(object sender, EventArgs e)
        {
            int score = 0;

            Button currB = (Button)sender;
            if (currB.StyleId == "3oK")
            {
                score = CheckThreeFourFiveKinds(3);
            }

            if (score == 1)
            {
                score = Convert.ToInt32(BtnDice1.Text) +
                        Convert.ToInt32(BtnDice2.Text) +
                        Convert.ToInt32(BtnDice3.Text) +
                        Convert.ToInt32(BtnDice4.Text) +
                        Convert.ToInt32(BtnDice5.Text);

            }

            String updateLabel = "Lbl" + currB.StyleId;
            Label l = (Label)FindByName(updateLabel);
            l.Text = score.ToString();


            if (currB.StyleId == "3oK")
            {
                currB.ClassId = "locked";
                currB.IsEnabled = false;
                BtnDiceRoll.IsEnabled = true;
            }


            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";

            totalLowScore();
            allButtonsClicked();

        }

        private void BtnFourKind_Clicked(object sender, EventArgs e)
        {
            int score = 0;

            Button currB = (Button)sender;

            if (currB.StyleId == "4oK")
            {
                score = CheckThreeFourFiveKinds(4);
            }
            if (score == 1)
            {
                score = Convert.ToInt32(BtnDice1.Text) +
                        Convert.ToInt32(BtnDice2.Text) +
                        Convert.ToInt32(BtnDice3.Text) +
                        Convert.ToInt32(BtnDice4.Text) +
                        Convert.ToInt32(BtnDice5.Text);

            }

            String updateLabel = "Lbl" + currB.StyleId;
            Label l = (Label)FindByName(updateLabel);
            l.Text = score.ToString();


            if (currB.StyleId == "4oK")
            {
                currB.ClassId = "locked";
                currB.IsEnabled = false;
                BtnDiceRoll.IsEnabled = true;
            }


            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";
            totalLowScore();
            allButtonsClicked();
        }

        private void BtnYahtzee_Clicked(object sender, EventArgs e)
        {
            int scoreYahtzee = 50;

            Button currYahtzee = (Button)sender;

            if (currYahtzee.StyleId == "Yahtzee")
            {
                scoreYahtzee = CheckThreeFourFiveKinds(5);
            }
            if (scoreYahtzee == 1)
            {
                scoreYahtzee = 50;

            }


            String updateLabel = "Lbl" + currYahtzee.StyleId;
            Label l = (Label)FindByName(updateLabel);
            l.Text = scoreYahtzee.ToString();


            if (currYahtzee.StyleId == "Yahtzee")
            {
                currYahtzee.ClassId = "locked";
                currYahtzee.IsEnabled = false;
                BtnDiceRoll.IsEnabled = true;
            }


            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";
            totalLowScore();
            allButtonsClicked();



        }

        private void BtnChance_Clicked(object sender, EventArgs e)
        {
            Button currChance = (Button)sender;
            int scoreChance = 0;
            string numberChanceValue = currChance.StyleId;

            scoreChance = Convert.ToInt32(BtnDice1.Text) +
                          Convert.ToInt32(BtnDice2.Text) +
                          Convert.ToInt32(BtnDice3.Text) +
                          Convert.ToInt32(BtnDice4.Text) +
                          Convert.ToInt32(BtnDice5.Text);



            if (currChance.StyleId == "Chance")
            {
                currChance.ClassId = "locked";
                currChance.IsEnabled = false;
            }
            string lblName = "Lbl" + numberChanceValue;
            Label UpdateThisLabel = (Label)FindByName(lblName);
            UpdateThisLabel.Text = scoreChance.ToString();

            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";

            if (currChance.StyleId == "locked")
            {
                BtnDiceRoll.IsEnabled = true;
            }

            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";
            totalLowScore();
            allButtonsClicked();
        }

        private void BtnFiveRow_Clicked(object sender, EventArgs e)
        {
            int diceValue;
            int largeScore = 0;

            Button curr5Row = (Button)sender;

            string numberValue = curr5Row.StyleId;

            if (curr5Row.StyleId == "5Row")
            {
                curr5Row.ClassId = "locked";
                curr5Row.IsEnabled = false;

                int[] largeStraight = new int[6] { 0, 0, 0, 0, 0, 0 };     //  {   dice1val, dice2val, dice3val, dice4val, dice5val    }

                diceValue = Convert.ToInt32(BtnDice1.Text);
                largeStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice2.Text);
                largeStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice3.Text);
                largeStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice4.Text);
                largeStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice5.Text);
                largeStraight[diceValue - 1]++;

                if ((largeStraight[0] >= 0 && largeStraight[1] >= 1 && largeStraight[2] >= 1 && largeStraight[3] >= 1 && largeStraight[4] >= 1 && largeStraight[5] >= 1) ||
                    (largeStraight[0] >= 1 && largeStraight[1] >= 1 && largeStraight[2] >= 1 && largeStraight[3] >= 1 && largeStraight[4] >= 1 && largeStraight[5] >= 0))


                {
                    largeScore = 40;
                    Lbl5Row.Text = largeScore.ToString();

                }
                else if (largeScore == 0)
                {
                    Lbl5Row.Text = largeScore.ToString();
                }

            }
            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";

            totalLowScore();
            allButtonsClicked();
        }

        private void BtnFourRow_Clicked(object sender, EventArgs e)
        {
            int diceValue;
            int smallScore = 0;

            Button curr4Row = (Button)sender;

            string numberValue = curr4Row.StyleId;

            if (curr4Row.StyleId == "4Row")
            {
                curr4Row.ClassId = "locked";
                curr4Row.IsEnabled = false;

                int[] smallStraight = new int[6] { 0, 0, 0, 0, 0, 0 };     //  {   dice1val, dice2val, dice3val, dice4val, dice5val    }

                diceValue = Convert.ToInt32(BtnDice1.Text);
                smallStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice2.Text);
                smallStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice3.Text);
                smallStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice4.Text);
                smallStraight[diceValue - 1]++;

                diceValue = Convert.ToInt32(BtnDice5.Text);
                smallStraight[diceValue - 1]++;

                if ((smallStraight[0] >= 1 && smallStraight[1] >= 2 && smallStraight[2] >= 3 && smallStraight[3] >= 4 && smallStraight[4] >= 5 && smallStraight[5] >= 6) ||
                    (smallStraight[0] >= 0 && smallStraight[1] >= 1 && smallStraight[2] >= 1 && smallStraight[3] >= 1 && smallStraight[4] >= 1 && smallStraight[5] >= 0) ||
                    (smallStraight[0] >= 0 && smallStraight[1] >= 0 && smallStraight[2] >= 1 && smallStraight[3] >= 1 && smallStraight[4] >= 1 && smallStraight[5] >= 1))

                {
                    smallScore = 30;
                    Lbl4Row.Text = smallScore.ToString();

                }
                else if (smallScore == 0)
                {
                    Lbl4Row.Text = smallScore.ToString();
                }
                totalLowScore();
                allButtonsClicked();

            }



            //  fix below   -   (Index Issue)



            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";

            totalLowScore();


        }

        private void BtnFullHouse_Clicked(object sender, EventArgs e)
        {
            Button currB = (Button)sender;

            bool twoKind = false;
            bool threeKind = false;

            int HouseValue = 0;

            int HaveFullHouse = 0;
            int diceValueF;

            int[] totalHouseNumber = new int[6] { 0, 0, 0, 0, 0, 0 };



            diceValueF = Convert.ToInt32(BtnDice1.Text); //Gets the number on the dice
            totalHouseNumber[diceValueF - 1]++; //reads dice value (- 1) to increment it in the array

            diceValueF = Convert.ToInt32(BtnDice2.Text);
            totalHouseNumber[diceValueF - 1]++;

            diceValueF = Convert.ToInt32(BtnDice3.Text);
            totalHouseNumber[diceValueF - 1]++;

            diceValueF = Convert.ToInt32(BtnDice4.Text);
            totalHouseNumber[diceValueF - 1]++;

            diceValueF = Convert.ToInt32(BtnDice5.Text);
            totalHouseNumber[diceValueF - 1]++;

            for (int i = 0; i < totalHouseNumber.Length; i++)
            {
                if (totalHouseNumber[i] == 2)
                {
                    twoKind = true;
                }
                if (totalHouseNumber[i] == 3)
                {
                    threeKind = true;
                }
                if (twoKind == true && threeKind == true)
                {
                    LblFullHouse.Text = 25.ToString();
                }
                else
                    LblFullHouse.Text = 0.ToString();





                if (currB.StyleId == "FullHouse")
                {
                    currB.ClassId = "locked";
                    currB.IsEnabled = false;
                    BtnDiceRoll.IsEnabled = true;
                }

            }
            BtnDice1.StyleId = "Roll";
            BtnDice1.BackgroundColor = Color.White;
            BtnDice1.Text = "";

            BtnDice2.StyleId = "Roll";
            BtnDice2.BackgroundColor = Color.White;
            BtnDice2.Text = "";

            BtnDice3.StyleId = "Roll";
            BtnDice3.BackgroundColor = Color.White;
            BtnDice3.Text = "";

            BtnDice4.StyleId = "Roll";
            BtnDice4.BackgroundColor = Color.White;
            BtnDice4.Text = "";

            BtnDice5.StyleId = "Roll";
            BtnDice5.BackgroundColor = Color.White;
            BtnDice5.Text = "";


            _TurnRoll = 1;
            LblRollNumber.Text = "Start your next turn!";

            totalLowScore();
            allButtonsClicked();



        }

        private async void ResetBoard_Clicked(object sender, EventArgs e)
        {

            bool appRestart = await DisplayAlert("Restart Game!", "Are you sure you want to start a new Game?", "Yes", "No");
            if (appRestart == true)
            {
                appRestart = true;

                BtnOnes.IsEnabled = true;
                BtnTwos.IsEnabled = true;
                BtnThrees.IsEnabled = true;
                BtnFours.IsEnabled = true;
                BtnFives.IsEnabled = true;
                BtnSixes.IsEnabled = true;

                BtnThreeKind.IsEnabled = true;
                BtnFourKind.IsEnabled = true;
                BtnYahtzee.IsEnabled = true;
                BtnFourRow.IsEnabled = true;
                BtnFiveRow.IsEnabled = true;
                BtnChance.IsEnabled = true;
                BtnFullHouse.IsEnabled = true;


                BtnDice1.StyleId = "Roll";
                BtnDice1.BackgroundColor = Color.White;
                BtnDice1.Text = "";

                BtnDice2.StyleId = "Roll";
                BtnDice2.BackgroundColor = Color.White;
                BtnDice2.Text = "";

                BtnDice3.StyleId = "Roll";
                BtnDice3.BackgroundColor = Color.White;
                BtnDice3.Text = "";

                BtnDice4.StyleId = "Roll";
                BtnDice4.BackgroundColor = Color.White;
                BtnDice4.Text = "";

                BtnDice5.StyleId = "Roll";
                BtnDice5.BackgroundColor = Color.White;
                BtnDice5.Text = "";

                

                Lbl1.Text = "";
                Lbl2.Text = "";
                Lbl3.Text = "";
                Lbl4.Text = "";
                Lbl5.Text = "";
                Lbl6.Text = "";
                Lbl3oK.Text = "";
                Lbl4oK.Text = "";
                LblYahtzee.Text = "";
                Lbl4Row.Text = "";
                Lbl5Row.Text = "";
                LblChance.Text = "";
                LblFullHouse.Text = "";

                LblUpperBonus.Text = "";

                LblLowTotal.Text = "";
                LblUpTotal.Text = "";


            }

            _TurnRoll = 1;
            LblRollNumber.Text = "Start the game by Rolling the Dice!";
            allButtonsClicked();
            HighScore();
        }
        
        private async void allButtonsClicked()
        {
            if (BtnOnes.IsEnabled == false &&
               BtnTwos.IsEnabled == false &&
               BtnThrees.IsEnabled == false &&
               BtnFours.IsEnabled == false &&
               BtnFives.IsEnabled == false &&
               BtnSixes.IsEnabled == false &&

               BtnThreeKind.IsEnabled == false &&
               BtnFourKind.IsEnabled == false &&
               BtnYahtzee.IsEnabled == false &&
               BtnFourRow.IsEnabled == false &&
               BtnFiveRow.IsEnabled == false &&
               BtnChance.IsEnabled == false &&
               BtnFullHouse.IsEnabled == false)
            {
                bool appRestart1 = await DisplayAlert("Your Game is finished!", "Do you sure you want to start a new Game?", "Yes", "No");
                if (appRestart1 == true)
                {
                    appRestart1 = true;
                    BtnOnes.IsEnabled = true;
                    BtnTwos.IsEnabled = true;
                    BtnThrees.IsEnabled = true;
                    BtnFours.IsEnabled = true;
                    BtnFives.IsEnabled = true;
                    BtnSixes.IsEnabled = true;

                    BtnThreeKind.IsEnabled = true;
                    BtnFourKind.IsEnabled = true;
                    BtnYahtzee.IsEnabled = true;
                    BtnFourRow.IsEnabled = true;
                    BtnFiveRow.IsEnabled = true;
                    BtnChance.IsEnabled = true;
                    BtnFullHouse.IsEnabled = true;
                    HighScore();


                    BtnDice1.StyleId = "Roll";
                    BtnDice1.BackgroundColor = Color.White;
                    BtnDice1.Text = "";

                    BtnDice2.StyleId = "Roll";
                    BtnDice2.BackgroundColor = Color.White;
                    BtnDice2.Text = "";

                    BtnDice3.StyleId = "Roll";
                    BtnDice3.BackgroundColor = Color.White;
                    BtnDice3.Text = "";

                    BtnDice4.StyleId = "Roll";
                    BtnDice4.BackgroundColor = Color.White;
                    BtnDice4.Text = "";

                    BtnDice5.StyleId = "Roll";
                    BtnDice5.BackgroundColor = Color.White;
                    BtnDice5.Text = "";



                    Lbl1.Text = "";
                    Lbl2.Text = "";
                    Lbl3.Text = "";
                    Lbl4.Text = "";
                    Lbl5.Text = "";
                    Lbl6.Text = "";
                    Lbl3oK.Text = "";
                    Lbl4oK.Text = "";
                    LblYahtzee.Text = "";
                    Lbl4Row.Text = "";
                    Lbl5Row.Text = "";
                    LblChance.Text = "";
                    LblFullHouse.Text = "";

                    LblUpperBonus.Text = "";

                    LblLowTotal.Text = "";
                    LblUpTotal.Text = "";
                    
                    _TurnRoll = 1;
                    LblRollNumber.Text = "Start the game by Rolling the Dice!";
                }

                

                
                
            }

        }

        private void HighScore()
        {
            totalLowScore();
            totalUpScore();

            int HighScore;

            HighScore = Convert.ToInt32(LblUpTotal.Text) +
                        Convert.ToInt32(LblLowTotal.Text);

            LblScoretoBeat.Text = HighScore.ToString();


            

        }
    }
}





