using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace K018A1818_kojinseisaku01.Device
{
    class Renderer
    {
        private ContentManager contentManager;
        private GraphicsDevice graphicsDevice;
        private SpriteBatch spriteBatch;

        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphicsDevice);
        }

        public void Begin()
        {
            spriteBatch.Begin();
        }

        public void Unload()
        {
            textures.Clear();//Dictionaryの情報をクリア
        }

        public void End()
        {
            spriteBatch.End();
        }

        public void DrawTexture(string assetName, Vector2 position, float alpha = 1.0f)
        {
            //デバッグモードの時のみ、画像描画前のアセット名チェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

            spriteBatch.Draw(textures[assetName], position, Color.White * alpha);
        }

        public void DrawTexture(string assetName, Vector2 position, Rectangle rect, float alpha = 1.0f)
        {
            //デバッグモードの時のみ、画像描画前のアセット名チェック
            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、画像の読み込み自体できていません");

            spriteBatch.Draw(
                textures[assetName], //テクスチャ
                position,            //位置
                rect,                //指定範囲（矩形で指定：左上の座標、幅、高さ）
                Color.White * alpha);//透明値
        }

        public void LoadContent(string assetName, string filepath = "./")
        {
            //すでにキー（assetName：アセット名）が登録されているとき
            if (textures.ContainsKey(assetName))
            {
#if DEBUG //DEBUGモードの時のみ下記エラー分をコンソールへ表示
                Console.WriteLine(assetName + "はすでに読み込まれています。\n プログラムを確認してください。");
#endif

                //それ以上読み込まないのでここで終了
                return;
            }
            //画像の読み込みとDictionaryへアセット名と画像を登録
            textures.Add(assetName, contentManager.Load<Texture2D>(filepath + assetName));

        }

        public void DrawTexture(
          string assetName,
          Vector2 positoin,
          Rectangle? rect,
          float rotate,
          Vector2 rotatePosition,
          Vector2 scale,
          SpriteEffects effects = SpriteEffects.None,
          float depth = 0.0f,
          float alpha = 1.0f)
        {
            spriteBatch.Draw(
                textures[assetName],
                positoin,
                rect,
                Color.White * alpha,
                rotate,
                rotatePosition,
                scale,
                effects,
                depth);
        }


        public void DrawNumber(
          string assetName,
          Vector2 position,
          int number,
          float alpha = 1.0f)
        {

            Debug.Assert(
                textures.ContainsKey(assetName),
                "描画時にアセット名の指定を間違えたか、" +
                "画像の読み込み自体できていません");

            if (number < 0)
            {
                number = 0;
            }

            int width = 97;

            foreach (var n in number.ToString())
            {
                //数字のテクスチャが数字1つにつき幅32高さ64
                //文字と文字を引き算し、整数値を所得している
                spriteBatch.Draw(
                    textures[assetName],
                    position,
                    new Rectangle((n - '0') * width, 0, width, 121),
                    Color.White);

                position.X += width;
            }
        }
    }
}

