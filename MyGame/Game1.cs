using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D postac;
    private Vector2 postac_xy;
    private bool skok = false;
    private float czas_skoku = 0.0f;
    private float stratY = 0;
    private float kat = 0.0f;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        if (GraphicsDevice == null)
        {
            _graphics.ApplyChanges();
        }

        _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
        _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;

        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        postac = Content.Load<Texture2D>("postac");
        postac_xy.Y = 300;
        stratY = postac_xy.Y;
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState klawisz = Keyboard.GetState();
        if (klawisz.IsKeyDown(Keys.LeftShift))
        
        {
            if (skok)
            {
                postac_xy.Y += czas_skoku;
                czas_skoku += 1;
                if (postac_xy.Y >= stratY)
                {
                    postac_xy.Y = stratY;
                    skok = false;
                }
            }
            else
            {
                if (klawisz.IsKeyDown(Keys.Space))
                {
                    skok = true;
                    czas_skoku = -15;
                }
            }
            if (postac_xy.X + postac.Width < _graphics.PreferredBackBufferWidth)
            {
                if (klawisz.IsKeyDown(Keys.D))
                {
                    postac_xy.X += 10;
                    postac = Content.Load<Texture2D>("postac3");
                }
            }
            if (postac_xy.X > 0)
            {
                if (klawisz.IsKeyDown(Keys.A))
                {
                    postac_xy.X -= 10;
                    postac = Content.Load<Texture2D>("postac4");
                }
            }
        }
        else
        {
            if (skok)
            {
                postac_xy.Y += czas_skoku;
                czas_skoku += 1;
                if (postac_xy.Y >= stratY)
                {
                    postac_xy.Y = stratY;
                    skok = false;
                }
            }
            else
            {
                if (klawisz.IsKeyDown(Keys.Space))
                {
                    skok = true;
                    czas_skoku = -15;
                }
            }
            if (postac_xy.X + postac.Width < _graphics.PreferredBackBufferWidth)
            {
                if (klawisz.IsKeyDown(Keys.D))
                {
                    postac_xy.X += 10;
                    postac = Content.Load<Texture2D>("postac");
                }
            }
            if (postac_xy.X > 0)
            {
                if (klawisz.IsKeyDown(Keys.A))
                {
                    postac_xy.X -= 10;
                    postac = Content.Load<Texture2D>("postac2");
                }
            }
        }



        // TODO: Add your update logic here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        Vector2 obrot = new Vector2();
        _spriteBatch.Draw(postac, postac_xy, null, Color.White, kat, obrot, 1.01f, SpriteEffects.None, 1);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}