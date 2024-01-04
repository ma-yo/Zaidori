using System;
using System.Diagnostics;
using System.Linq;
using Zaidori.Datas;
using static System.Net.Mime.MediaTypeNames;

namespace Zaidori
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// クリアボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            try
            {
                MaterialGrid.Rows.Clear();
                InputGrid.Rows.Clear();
                AsariText.Text = "3";
                MemoText.Text = "";
                MaterialGrid.Focus();
                MaterialGrid.CurrentCell = MaterialGrid.Rows[0].Cells[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// フォーム表示時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                ClearButton.PerformClick();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 計算ボタンのクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(!int.TryParse(AsariText.Text, out int asari))
                {
                    MessageBox.Show(this, "あさり寸法が不正です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    AsariText.Focus();
                    return;
                }

                List<decimal> materialSizeList = new List<decimal>();
                foreach(DataGridViewRow row in MaterialGrid.Rows)
                {
                    if(decimal.TryParse("" + row.Cells[0].Value, out decimal material))
                    {
                        if (material > 0)
                        {
                            materialSizeList.Add(material);
                        }
                    }
                }
                if(materialSizeList.Count == 0)
                {
                    MessageBox.Show(this, "原材料が不正です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    MaterialGrid.Focus();
                    return;
                }

                //入力データを1本単位にし、配列化する。
                List<decimal> inputList = new List<decimal>();
                foreach (DataGridViewRow row in InputGrid.Rows)
                {
                    bool sizeResult = decimal.TryParse("" + row.Cells[0].Value, out decimal size);
                    bool quantResult = int.TryParse("" + row.Cells[1].Value, out int quant);
                    if(sizeResult && quantResult && size > 0 && quant > 0)
                    {
                        for(int i = 0; i < quant; ++i)
                        {
                            inputList.Add(size);
                        }
                    }
                }
                if(inputList.Count > 25)
                {
                    MessageBox.Show(this, "取り合わせ可能な最大数は25本までです。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                List<OutputData> compList = new List<OutputData>();
                //入力データをすべて処理するまでループ
                while (inputList.Count > 0)
                {
                    //原材料サイズ内に収まる総当たりを取得する
                    List<List<decimal>> kohoList = GetPermutation(materialSizeList, inputList, asari);
                    if(kohoList.Count == 0)
                    {
                        MessageBox.Show(this, "取り合わせ可能な組み合わせは存在しませんでした。", "取り合わせエラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    decimal budomari = 0;
                    List<OutputData> outputSizeList = new List<OutputData>();
                    //最も歩留まりの高い候補を1つ取得する
                    foreach (var materialSize in materialSizeList)
                    {
                        foreach (var result in kohoList)
                        {
                            decimal tmpBudomari = GetBudomari(result, asari, materialSize);
                            if (tmpBudomari <= 1 && tmpBudomari > budomari)
                            {
                                budomari = tmpBudomari;
                            }
                        }
                    }

                    //最も歩留まりの高い候補と同じ歩留まりのものをすべてセットする
                    foreach (var materialSize in materialSizeList)
                    {
                        foreach (var result in kohoList)
                        {
                            decimal tmpBudomari = GetBudomari(result, asari, materialSize);
                            if (tmpBudomari <= 1 && tmpBudomari == budomari)
                            {
                                OutputData output = new OutputData();
                                output.SizeList = result;
                                output.Budomari = budomari;
                                output.MaterialSize = materialSize;
                                outputSizeList.Add(output);
                            }
                        }
                    }

                    //一番高い歩留まりが良いものを採用し、入力データから確定データを削除する。
                    foreach(var koho in outputSizeList)
                    {
                        compList.Add(koho);
                        for (int i = 0; i < koho.SizeList.Count; ++i)
                        {
                            for (int j = 0; j < inputList.Count; ++j)
                            {
                                if (koho.SizeList[i] == inputList[j])
                                {
                                    inputList.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                    }
                }
                
                string outputFile = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmss") + "_result.txt";
                using(StreamWriter sw = new StreamWriter(outputFile, false, System.Text.Encoding.Default)){
                    sw.WriteLine("メモ : " + MemoText.Text);

                    Dictionary<decimal, int> materialInfo = new Dictionary<decimal, int>();
                    foreach (var result in compList.OrderByDescending(a => a.MaterialSize).ThenByDescending(a => a.SizeList.Sum()))
                    {
                        if (!materialInfo.ContainsKey(result.MaterialSize))
                        {
                            materialInfo.Add(result.MaterialSize, 0);
                        }
                        materialInfo[result.MaterialSize]++;
                        string str = "";
                        foreach (var size in result.SizeList)
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                str += " , ";
                            }
                            str += size.ToString();
                        }
                        sw.WriteLine("原材料 : " + result.MaterialSize + " , 歩留まり率 : " + String.Format("{0:P}", result.Budomari) + " , " + str);
                    }
                    sw.WriteLine("----------------------------------------------------------------------------------");
                    sw.WriteLine("Total:");
                    foreach(var material in materialInfo)
                    {
                        sw.WriteLine("原材料 : " + material.Key + " , 必要本数 : " + material.Value + "本");
                    }
                    sw.WriteLine("----------------------------------------------------------------------------------");
                }

                Process.Start("notepad.exe", outputFile);

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 歩留まり率を取得する
        /// </summary>
        /// <param name="sizeList"></param>
        /// <param name="asari"></param>
        /// <param name="materialSize"></param>
        /// <returns></returns>
        private decimal GetBudomari(List<decimal> sizeList, int asari, decimal materialSize)
        {
            try
            {
                int asariSum = (sizeList.Count - 1) * asari;
                decimal totalSize = asariSum + sizeList.Sum();
                decimal budomari = totalSize / materialSize;
                return budomari;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<List<decimal>> GetPermutation(List<decimal> materialList, List<decimal> inputList, int asari)
        {
            try
            {
                decimal materialMax = materialList.Max();
                List<List<decimal>> patternList = new List<List<decimal>>();
                int maxIdx = 0;
                decimal size = 0;
                //処理高速化のため、最小寸法の合計が原材料サイズを超えるまでのパターン数とする
                foreach(var input in inputList.OrderBy(a => a))
                {
                    if(size > 0)
                    {
                        size += asari;
                    }
                    size += input;
                    if(size <= materialMax)
                    {
                        maxIdx++;
                    }
                    else
                    {
                        break;
                    }
                }
                for (int idx = 1; idx <= inputList.Count; ++idx)
                {
                    int patternQuant = idx;
                    if(idx > maxIdx)
                    {
                        patternQuant = maxIdx;
                    }
                    Combinatorics.Collections.Combinations<decimal> combinations = new Combinatorics.Collections.Combinations<decimal>(inputList, patternQuant, Combinatorics.Collections.GenerateOption.WithoutRepetition);
                     int asariDiv = (idx - 1) * asari;
                    foreach (var combination in combinations)
                    {
                        if (materialMax >= combination.Sum() + asariDiv)
                        {
                            List<decimal> combinationList = combination.OrderBy(a => a).ToList();
                            bool sameAryExists = false;
                            foreach (var pattern in patternList)
                            {
                                //2つのシーケンスが等しいか調べる
                                if (pattern.SequenceEqual(combinationList))
                                {
                                    sameAryExists = true;
                                    break;
                                }
                            }
                            if (!sameAryExists)
                            {
                                patternList.Add(combinationList);
                            }
                        }
                    }
                }

                List<List<decimal>> resultList = new List<List<decimal>>();
                foreach (var pattern in patternList)
                {
                    Combinatorics.Collections.Permutations<decimal> permutations = new Combinatorics.Collections.Permutations<decimal>(pattern, Combinatorics.Collections.GenerateOption.WithoutRepetition);

                    foreach (var permutation in permutations)
                    {
                        List<decimal> decPermutation = permutation.OrderBy(a => a).ToList();
                        bool sameExists = false;
                        foreach (var result in resultList)
                        {
                            if (result.SequenceEqual(decPermutation))
                            {
                                sameExists = true;
                                break;
                            }
                        }
                        if (!sameExists)
                        {
                            resultList.Add(decPermutation);
                        }
                    }
                }
                return resultList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
