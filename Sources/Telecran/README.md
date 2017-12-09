# Un Telecran en Visual Studio C\# #

Le telecran est un jeu qui permet de dessiner sur un écran. Cette version utilise les flèches de direction du clavier pour déplacer un curseur qui dessine une ligne, horizontale ou verticale.

![TelecranC#](telecran.png)

Nécessite les objets suivants :

    private Graphics g;
    private Bitmap b;
    private Pen myPen = new Pen(Color.Red, 3);
    private Point p1, p2;

Au chargement du formulaire :

- Création d'une image bitmap qui occupe toute la fenêtre
- Création d'un graphique sur l'image
- Création des points au centre de la fenêtre
- Permettre l'utilisation des touches de directions : `this.KeyPreview = true;` 

Dans Form_Load():

    b = new Bitmap(Width, Height);
    g = Graphics.FromImage(b);
    p1 = new Point(this.Width / 2, this.Height / 2);
    p2 = new Point();
    p2 = p1;
    this.KeyPreview = true;

Produire l'événement pour repeindre le formulaire :

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
    	e.Graphics.DrawImage(b, 0, 0);
    }

Gérer les événements produits par l'appui sur une touche

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
	    switch(e.KeyCode) 
	    {
		    case (Keys.Up): toUp();  break;
		    case (Keys.Left): toLeft(); break;
		    case (Keys.Right): toRight(); break;
		    case (Keys.Down): toDown(); break;
	    }
    } 