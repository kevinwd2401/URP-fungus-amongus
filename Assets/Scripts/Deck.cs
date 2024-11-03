using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{

    public List<Card> cards;
    public List<Card> discard_pile;
    public List<Card> draw_pile;
    public Card[] hand;
    public Buttons buttons;
    int handsize = 5;

    public Text draw_pile_text;

    public Deck() {
        cards = new List<Card>();
        discard_pile = new List<Card>();
        draw_pile = new List<Card>();
        hand = new Card[handsize];

    }

    public void fillDeckWithStarter() {
        this.cards.Clear();
        //this.cards.Add(new Card(CardType.HorizontalStep));
        //this.cards.Add(new Card(CardType.HorizontalStep));
        //this.cards.Add(new Card(CardType.HorizontalStep));
        //this.cards.Add(new Card(CardType.DiagonalStep));
        this.cards.Add(new Card(CardType.Slash));
        this.cards.Add(new Card(CardType.Slash));
        this.cards.Add(new Card(CardType.Slash));
        this.cards.Add(new Card(CardType.Slash));
        this.cards.Add(new Card(CardType.SpinSlash));
        this.cards.Add(new Card(CardType.LunarSlash));
    }

    public void resetDeck() {
        for(int i = 0; i < hand.Length; ++i) {
            hand[i] = null;
        }
        discard_pile.Clear();
        draw_pile.Clear();
        draw_pile.AddRange(cards);
    }

    public void reshuffleDiscard() {
        draw_pile.AddRange(discard_pile);
        discard_pile.Clear();
        shuffleDrawPile();
    }

    public void shuffleDrawPile() {
        
        for (int i = draw_pile.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (draw_pile[i], draw_pile[j]) = (draw_pile[j], draw_pile[i]);
        }
    }

    public void discardByIndex(int index) {
        if (index < 0 || index >= hand.Length)
        {
            //ignore call
            return;
        }
        if (hand[index] == null) {
            //ignore call
            return;
        }

        discard_pile.Add(hand[index]);
        hand[index] = null;
        updateDisplay();

    }

    public void discardAll() {
        for(int i = 0; i < handsize; ++i) {
            discardByIndex(i);
        }
    }

    public void drawCard() {
        //Check if deck empty, if yes reshuffle
        if (draw_pile.Count <= 0) {
            //If literally no cards left, stop
            if (discard_pile.Count <= 0) {
                return;
            }
            //else: reshuffle
            reshuffleDiscard();
        }
        //Check if hand full: if yes, discard it
        if (getCurrentHandSize() == handsize) {
            discard_pile.Add(draw_pile[0]);
            draw_pile.RemoveAt(0);
        } else {
            //get first free index
            int i = 0;
            while(hand[i] != null && i < handsize) {
                i++;
            }
            hand[i] = draw_pile[0];
            draw_pile.RemoveAt(0);
        }

        updateDisplay();
    }

    public int getCurrentHandSize() {
        int c = 0;

        for (int i = 0; i < handsize; i++) {
            if (hand[i] != null) {
                c++;
            }
        }

        return c;
    }

    void updateDisplay() {

        draw_pile_text.text = (draw_pile.Count).ToString(); 

        buttons.ClearButtons();
        for(int i = 0; i < hand.Length; ++i) {
            if (hand[i] != null) {
                buttons.LoadButtonAt(hand[i].name, i);
            }    
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        fillDeckWithStarter();
        resetDeck();
        shuffleDrawPile();

        drawCard();
        drawCard();
        drawCard();
        drawCard();
        drawCard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Card {
    public int cost;
    //public Skill skill;
    public string name;
    public string desc;
    
    public Card(int cost, string name, string desc) {
        this.cost = cost;
        this.name = name;
        this.desc = desc;
    }

    public Card(CardType t) {
        int c = 0;
        string n = "Default Card";
        string d = "This card does nothing.";

        switch (t) {
            case CardType.HorizontalStep : 
                c = 0;
                //s = HorizontalStep();
                n = "Horizontal Step";
                d = "Move horizontally for 1 tile.";
                break;
            case CardType.DiagonalStep : 
                c = 0;
                //s = DiagonalStep();
                n = "Diagonal Step";
                d = "Move diagonally for 1 tile.";
                break;
            case CardType.Slash : 
                c = 1;
                //s = Slash();
                n = "Slash";
                d = "deal 1 DMG to 3 connected surrounding tiles";
                break;
            case CardType.SpinSlash : 
                c = 1;
                //s = SpinSlash();
                n = "Spin Slash";
                d = "deal 1 DMG to all surrounding tiles";
                break;
            case CardType.LunarSlash : 
                c = 1;
                //s = SpinSlash();
                n = "Spin Slash";
                d = "deal 2 DMG to 3 tiles in horizontal direction";
                break;
            default:
                break;
        }

        //temp, default, all cards are slash 
        //s = new Slash();
        
        this.cost = c;
        //this.skill = s;
        this.name = n;
        this.desc = d;
    }
}

public enum CardType {
    HorizontalStep, DiagonalStep, Slash, SpinSlash, LunarSlash
}