// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using K018A1818_kojinseisaku01.Actor;
using K018A1818_kojinseisaku01.Def;
using K018A1818_kojinseisaku01.Device;
using K018A1818_kojinseisaku01.Scene;
using K018A1818_kojinseisaku01.Utill;


using System.Collections.Generic;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace K018A1818_kojinseisaku01
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト
       
        private GameDevice gameDevice;
        private SceneManager sceneManager;
        private Renderer renderer;



        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";

            graphicsDeviceManager.PreferredBackBufferWidth = Screen.Width;
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.Height;

        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述

            gameDevice = GameDevice.Instance(Content, GraphicsDevice);
                     
            sceneManager = new SceneManager();

            sceneManager.Add(Scene.Scene.Title, new Title());
            sceneManager.Add(Scene.Scene.Tutorial, new Tutorial());
            sceneManager.Add(Scene.Scene.GamePlay,new GamePlay());

            sceneManager.Add(Scene.Scene.Ending, new Ending());
            sceneManager.Add(Scene.Scene.GameClear, new GameClear());
            sceneManager.Change(Scene.Scene.Title);
            

            // この上にロジックを記述
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // この下にロジックを記述
            
            renderer = new Renderer(Content, GraphicsDevice);

            renderer = gameDevice.GetRenderer();

            renderer.LoadContent("Title");
            renderer.LoadContent("Over");
            renderer.LoadContent("Clear");
            renderer.LoadContent("stage");

            renderer.LoadContent("player");
            renderer.LoadContent("enemy");
            renderer.LoadContent("Shoot");
            renderer.LoadContent("Item");
            renderer.LoadContent("boss");
            renderer.LoadContent("toumei");

            renderer.LoadContent("animation");
            renderer.LoadContent("animationbig");

            renderer.LoadContent("tutorial1");
            renderer.LoadContent("tutorial2");
            renderer.LoadContent("tutorial3");
            renderer.LoadContent("tutorial4");

            Sound sound = gameDevice.GetSound();
            string filepathBGM = "./BGM/";
            sound.LoadBGM("Clear", filepathBGM);
            sound.LoadBGM("loop", filepathBGM);
            sound.LoadBGM("Over", filepathBGM);
            sound.LoadBGM("Title", filepathBGM);

            string filepathSE = "./SE/";
            sound.LoadSE("bomb2", filepathSE);
            sound.LoadSE("powerup05", filepathSE);
            sound.LoadSE("shot5", filepathSE);
            sound.LoadSE("titlese", filepathSE);

            // この上にロジックを記述
        }

        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                Exit();
            }

            // この下に更新ロジックを記述

            Input.Update();

            sceneManager.Update(gameTime);
            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述
            sceneManager.Draw(renderer);

            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}
