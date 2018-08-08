using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lektion_7._6_TicTacToe
{
    public partial class Form1 : Form
    {
        /*counter, denn es gibt maximal 9 Durchlaeufe*/
        int counter = 0;

        /*Button-Array*/

        Button[,] game = new Button[3, 3];





        public Form1()
        {
            InitializeComponent();

            /* im Konstruktor, nach dem initialisieren saemtlicher Komponenten,
             * werden alle Buttons dem entsprechenden Feld im Array zugeordnet*/

            game[0, 0] = btn00;
            game[0, 1] = btn01;
            game[0, 2] = btn02;
            game[1, 0] = btn10;
            game[1, 1] = btn11;
            game[1, 2] = btn12;
            game[2, 0] = btn20;
            game[2, 1] = btn21;
            game[2, 2] = btn22;

        }

        /*sind die Buttons alle den entsprechenden Feldern des Arrays zugewiesen worden
         benoetigen wir eine Ereignisprozedur , die fuer alle SchaltFlaechen gilt*/


        /* (object sender, EventArgs e) = StandardSignatur eines Ereignisprozesses
        alle Schaltflaechen muessen mit dieser Ereignisprozedur verknuepft werden
        --> Eigenschaften - Blitz - Click*/

         private void Btn_Click(object sender, EventArgs e)
        {
            /*bei jedem Click will ich erstmal wissen, welche Button-Instanz den Click ausgeloest hat,
             dazu wird erstmal eine ButtonVariable erstellt*/

            Button button = (Button)sender;         /*mit Hilfe expliziter Konvertierung wird der sender in das richtige ButtonObjekt
                                                 die Ereignisprozedur liefert im sender immer das Objekt mit, welches auf das Ereignis reagiert
                                                 dieses(Objekt) muss dann umgewandelt werden (in einen Button)
                                                 
                                                 der sender (vom DatenTyp object) - z.B. btn00 - liefert das Objekt mit welches auf das Clicken reagiert -->
                                                 hier: der Button btn00 ( vom DatenTyp Button)  --> dieses mitgelieferte Objekt (Button btn00)
                                                 wird in einer lokalen Variablen button   (vom Datentyp Button) zwischengespeichert
                                                 --> dafuer muss das object sender in Button konvertiert werden
                                                 
                                                also button ist gleich Button btn00 --> wird button Text zugewiesen, wird btn00 Text zugewiesen ( in diesem Bsp.Fall)*/

            /*damit ein Feld nicht 2mal geclickt werden kann, und somit sein Zeichenaendert
             wird vor dem inkrementierten counter geprueft ob im Button (auf den geclickt wird) schon ein Text ("X" oder "O") steht --> falls ja wurde auf den Button schon geclickt
             --> ist dem so, soll natuelich der counter nicht nochmal inkrementiert werden und der Text des buttons soll sich auch nicht aendern*/

            if(button.Text != "")
            {
                MessageBox.Show("Das Feld ist bereits belegt !");
                return;                       /*damit die Ereignisprozedur nicht weiter abgearbeitet wird --> ein return  --> verlaesst die Ereignisprozedur  -->
                                               private void Btn_Click(object sender, EventArgs e) , d.h. alles nach dem return wird nicht mehr ausgefuehrt -->
                                               kein counter inkrementiert und kein "x" oder "O" dem button.Text zugewiesen*/

            }

            /*bei jedem clicken soll der counter (der Form1) inkrementiert werden ( man kann nicht oefter als 9 mal clicken)*/

            ++counter;

            /*mit jedem Click soll abwechselnd ein X bzw. ein O als Beschriftung fuer den Button uebergeben werden */

            if (counter % 2 == 0)              /*prueft ob es (der Click) eine gerade Zahl ist*/
            {
                button.Text = "X";              /*ist der Click in der Form gerade, wird der lokalen Button-Variable der Text "X" hinzugefuegt -->
                                                 die lokale Button-Variable hat den Wert des senders(Buttons), der die Ereignisprozedur ausgelöst hat (hier btn00)
                                                 also wird btn00 der Text "X" zugewiesen*/
            }

            else                   /* bei ungeraden Zahlen (des Clicks)*/
            {
                button.Text = "O";
            }


            /*jetzt muss bei jedem Durchlauf getestet werden ob einer der Spieler bereits gewonnen hat
             als erstes werden alle 3 Zeilen des Spielfelds ueberprueft --> haben alle 3 Felder denselben Wert 
             hat einer der Spieler gewonnen (gilt nicht wenn alle 3 Felder leer sind*/

            /*da ich 3 Zeilen hab, bietet es sich an dies in einer Schleife zu ueberpruefen*/


            string win = "";                /*ich weiß nicht welcher Spieler ("X" oder "O") gewonnen hat-
                                             das werde ich mir in einer Variablen merken - 
                                             diese Variable wird vor dem SchleifenDurchlauf definiert*/



            for (int i = 0; i <= 2; ++i)                           /*i ist der Zeilenwert des game/Button-Arrays ("Button[,] game = new Button[3, 3]; 
                                                                  --> wurde gleich bei der Klasse Form1 als Eigenschaft mitgegeben  
                                                                  --> public partial class Form1 : Form { } ")*/
            {
                if (game[i, 0].Text != "" &&
                    game[i, 0].Text == game[i, 1].Text && game[i, 1].Text == game[i, 2].Text)        /* das game-Array (dessen Elemente die 9 Buttons sind) wird geprueft 
                                                                                                   --> je nach dem welche (Text-)Kombination im game-Array auftauchen, hat ein Spieler gewonnen

                                                                                                    Achtung! die Texteigenschaft der game-Array-Elemente werden geprueft -- diese sind ja laut Zuweisung Buttons (00 - 20)

                                                                                                   wenn die erste Spalte einer Zeile nicht leer ist und die 1. - 2. und 3. Spalte einer 
                                                                                                    Zeile uebereinstimmen*/
                {
                    win = game[i, 0].Text;           /*nur wenn einer der Spieler gewonnen hat, dann  wird die Variable win auf den Wert einer der Felder gesetzt 
                                                      - da alle 3 Felder denselben Wert haben, ist es egal welches Feld wir verwenden*/
                }

            }

            /*Spalten werden geprueft*/

            for (int i = 0; i <= 2; ++i)                           /*i ist der Spaltenwert des game/Button-Arrays ("Button[,] game = new Button[3, 3]; 
                                                                  --> wurde gleich bei der Klasse Form1 als Eigenschaft mitgegeben  
                                                                  --> public partial class Form1 : Form { } ")*/
            {
                if (game[0, i].Text != "" &&
                    game[0, i].Text == game[1, i].Text && game[1, i].Text == game[2, i].Text)        /* das game-Array (dessen Elemente die 9 Buttons sind) wird geprueft 
                                                                                                   --> je nach dem welche (Text-)Kombination im game-Array auftauchen, hat ein Spieler gewonnen
                                                                                                 

                                                                                                    Achtung! die Texteigenschaft der game-Array-Elemente werden geprueft -- diese sind ja laut Zuweisung Buttons (00 - 20)

                                                                                                   wenn die erste Zeile einer Zeile nicht leer ist und die 1. - 2. und 3. Zeile einer 
                                                                                                    Zeile uebereinstimmen*/
                {
                    win = game[0, i].Text;           /*nur wenn einer der Spieler gewonnen hat, dann  wird die Variable win auf den Wert einer der Felder gesetzt 
                                                      - da alle 3 Felder denselben Wert haben, ist es egal welches Feld wir verwenden*/
                }

            }


            /*Diagonalen pruefen*/

            if((game[0,0].Text == game[1,1].Text && game[1, 1].Text == game[2, 2].Text) || (game[0, 2].Text == game[1, 1].Text && game[1, 1].Text == game[2, 0].Text) )

            {
                win = game[1, 1].Text;
            }

            /*am Ende muss ueberprueft werden, ob entweder bereits 9 Clicks gemacht wurden und keiner gewonnen hat oder bereits ein Spieler gewonnen hat*/


            if (win != "")
            {
                MessageBox.Show("Spieler " + win + " hat gewonnen !");
                Application.Exit();                         /*Anwendung wird an dieser Stelle verlassen*/


            }


            else if (counter == 9)
            {
                MessageBox.Show("Das Spiel ist aus. Niemand hat gewonnen !");
                Application.Exit();
            }

        }
        
    }       
}

