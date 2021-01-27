using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
★入力例★　実行して、コンソールウインドウから以下のように入力して動作確認しましょう。（行末でEnterキー）
100 100 100 100
5
50 50 50 50
50 50 20 20
80 120 140 10
140 140 20 20
90 90 120 120

★出力例★　上記のテストデータでは、以下の結果が出たら正解です。
敵機1が当たり
敵機3が当たり
敵機4が当たり
敵機5が当たり
*/


namespace ConsoleApp1
{
    // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
    // ★★★★★　これは未完成です。check()メソッドを変更して完成させtください　			★★★★★
    // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★

    class Program
    {
        static int jikiX, jikiY, jikiW, jikiH;  // 自機の (x, y) と幅と高さ　※(x,y)は画像の左上
        static int tekiKazu; // 敵の個数
        static int[] tekiX = new int[100]; // 敵の x座標
        static int[] tekiY = new int[100]; // 敵の y座標
        static int[] tekiW = new int[100]; // 敵の 幅
        static int[] tekiH = new int[100]; // 敵の 高さ

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ConsoleKaraYomikomi();
            HennsuuKakuninHyouji();
            Check();
            Console.ReadLine(); // コンソールが閉じないように入力待ちさせてます
        }

        static void ConsoleKaraYomikomi()
        {
            string[] strJiki = Console.ReadLine().Trim().Split(' ');  // 1行を読み込んで配列に代入
            jikiX = int.Parse(strJiki[0]); // 自機のX
            jikiY = int.Parse(strJiki[1]); // 自機のY
            jikiW = int.Parse(strJiki[2]); // 自機の幅
            jikiH = int.Parse(strJiki[3]); // 自機の高さ

            var line = Console.ReadLine().Trim();  // 1行を読み込んでlineという変数に代入
            tekiKazu = int.Parse(line);  // 敵の個数

            for (var i = 0; i < tekiKazu; i++) // 敵の数だけ繰り返し
            {
                string[] strTeki = Console.ReadLine().Trim().Split(' ');
                tekiX[i] = int.Parse(strTeki[0]); // 敵のX
                tekiY[i] = int.Parse(strTeki[1]); // 敵のY
                tekiW[i] = int.Parse(strTeki[2]); // 敵の幅
                tekiH[i] = int.Parse(strTeki[3]); // 敵の高さ

            }
        }

        static void HennsuuKakuninHyouji()
        {
            Console.WriteLine("　　X座標, Y座標, 幅, 高さ");
            Console.WriteLine(("自機 ：" + jikiX + "," + jikiY + "," + jikiW + "," + jikiH));
            for (int i = 0; i < tekiKazu; ++i)
            {
                Console.WriteLine(("敵機" + (i + 1) + "：" + tekiX[i] + "," + tekiY[i] + "," + tekiW[i] + "," + tekiH[i]));
            }

        }

        static void Check()
        {
            for (int i = 0; i < tekiKazu; ++i)
            { // 敵をひとつづつチェックする
                bool atariFlag = false; // とりあえず「当たってない」とフラグを下げておく

                // 1.敵の左上の位置が自機画像の範囲に入っているかどうかをチェック
                if (jikiX <= tekiX[i] && tekiX[i] <= (jikiX + jikiW) && jikiY <= tekiY[i] && tekiY[i] <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }
                // 2.敵の右上の位置が自機画像の範囲に入っているかどうかをチェック
                // if (～～～～～～～～～) {　　～～～～　　}
                if (jikiX <= tekiX[i] && tekiX[i] <= (jikiX + jikiW) && jikiY <= tekiW[i] && tekiW[i] <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= tekiY[i] && tekiY[i] <= (jikiX + jikiW) && jikiY <= tekiH[i] && tekiH[i] <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= tekiW[i] && tekiW[i] <= (jikiX + jikiW) && jikiY <= tekiH[i] && tekiH[i] <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= (tekiX[i]+tekiW[i]) && (tekiX[i] + tekiW[i]) <= (jikiX + jikiW) && jikiY <= (tekiX[i] + tekiW[i]) && (tekiX[i] + tekiW[i]) <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= (tekiY[i] + tekiW[i]) && (tekiY[i] + tekiW[i]) <= (jikiX + jikiW) && jikiY <= (tekiY[i] + tekiW[i]) && (tekiY[i] + tekiW[i]) <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= (tekiX[i] + tekiH[i]) && (tekiX[i] + tekiH[i]) <= (jikiX + jikiW) && jikiY <= (tekiX[i] + tekiH[i]) && (tekiX[i] + tekiH[i]) <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }

                if (jikiX <= (tekiW[i] + tekiH[i]) && (tekiW[i] + tekiH[i]) <= (jikiX + jikiW) && jikiY <= (tekiW[i] + tekiH[i]) && (tekiW[i] + tekiH[i]) <= (jikiY + jikiH))
                {
                    atariFlag = true;
                }
                // ～～ などと、必要なチェックを作成してください。
                // ～～　どんなチェックが必要かはよく考えてみましょう。
                // ～～　いくつチェックすればいいのでしょうか。
                // ～～　効率的にチェックするアイデアは思いつきましたか？

                // atariFlagが true に変わっていたら結果を表示する
                if (atariFlag)
                {
                    Console.WriteLine("敵機" + (i + 1) + "が当たり");
                }
                else
                {
                    //Console.WriteLine("敵機" + (i+1) + "は当たってません。セーフ！");
                }
            }
        }
    }
}
