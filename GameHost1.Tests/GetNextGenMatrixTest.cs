﻿using System;
using FluentAssertions;
using Xunit;

namespace GameHost1.Tests
{
    public class GetNextGenMatrixPatternsTest
    {
        [Fact(DisplayName="穩定狀態1: 板凳(1)")]
        public void StaticPattern1Test()
        {
            PatternTest(
                new string[]
                    {
                        "11",
                        "11",
                    },
                new string[]
                    {
                        "11",
                        "11",
                    }
            ).Should().BeTrue();
        }

        [Fact(DisplayName="穩定狀態2: 麵包(1)")]
        public void StaticPattern2Test()
        {
            PatternTest(
                new string[]
                    {
                        "000000",
                        "001100",
                        "010010",
                        "001010",
                        "000100",
                        "000000",
                    },
                new string[]
                    {
                        "000000",
                        "001100",
                        "010010",
                        "001010",
                        "000100",
                        "000000",
                    }
            ).Should().BeTrue();
        }

        [Fact(DisplayName="穩定狀態3: 蜂巢(1)")]
        public void StaticPattern3Test()
        {
            PatternTest(
                new string[]
                    {
                        "000000",
                        "001100",
                        "010010",
                        "001100",
                        "000000",
                    },
                new string[]
                    {
                        "000000",
                        "001100",
                        "010010",
                        "001100",
                        "000000",
                    }
            ).Should().BeTrue();
        }

        [Fact(DisplayName="震盪狀態1: 信號燈(2)")]
        public void LoopPattern1Test()
        {
            PatternTest(
                new string[] {
                    "00000",
                    "00000",
                    "01110",
                    "00000",
                    "00000"
                },
                new string[] {
                    "00000",
                    "00100",
                    "00100",
                    "00100",
                    "00000"
                }
            ).Should().BeTrue(); 
            
            PatternTest(
                new string[] {
                    "00000",
                    "00100",
                    "00100",
                    "00100",
                    "00000"
                },
                new string[] {
                    "00000",
                    "00000",
                    "01110",
                    "00000",
                    "00000"
                }
            ).Should().BeTrue();
        }

        [Fact(DisplayName="震盪狀態2: 蟾蜍(2)")]
        public void LoopPattern2Test()
        {
            PatternTest(
                new string[] {
                    "000000",
                    "000000",
                    "001110",
                    "011100",
                    "000000",
                    "000000",
                },
                new string[] {
                    "000000",
                    "000100",
                    "010010",
                    "010010",
                    "001000",
                    "000000",
                }
            ).Should().BeTrue();
            PatternTest(
                new string[] {
                    "000000",
                    "000100",
                    "010010",
                    "010010",
                    "001000",
                    "000000",
                },
                new string[] {
                    "000000",
                    "000000",
                    "001110",
                    "011100",
                    "000000",
                    "000000",
                }
            ).Should().BeTrue();
        }
        [Fact(DisplayName="震盪狀態3: 烽火(2)")]
        public void LoopPattern3Test()
        {
            PatternTest(
                new string[] {
                        "000000",
                        "011000",
                        "010000",
                        "000010",
                        "000110",
                        "000000",
                },
                new string[] {
                        "000000",
                        "011000",
                        "011000",
                        "000110",
                        "000110",
                        "000000",
                }
            ).Should().BeTrue();
            PatternTest(
                new string[] {
                        "000000",
                        "011000",
                        "011000",
                        "000110",
                        "000110",
                        "000000",
                },
                new string[] {
                        "000000",
                        "011000",
                        "010000",
                        "000010",
                        "000110",
                        "000000",
                }
            ).Should().BeTrue();
        }
        [Fact(DisplayName="會移動的振盪狀態1: 滑翔機 (4)")]
        public void DynamicLoopPattern1Test()
        {
            PatternTest(
                new string[] {
                        "000000",
                        "010000",
                        "001100",
                        "011000",
                        "000000",
                        "000000",
                },
                new string[] {
                        "000000",
                        "001000",
                        "000100",
                        "011100",
                        "000000",
                        "000000",
                }
            ).Should().BeTrue();
            PatternTest(
                new string[] {
                        "000000",
                        "001000",
                        "000100",
                        "011100",
                        "000000",
                        "000000",
                },
                new string[] {
                        "000000",
                        "000000",
                        "010100",
                        "001100",
                        "001000",
                        "000000",
                }
            ).Should().BeTrue();
            PatternTest(
                new string[] {
                        "000000",
                        "000000",
                        "010100",
                        "001100",
                        "001000",
                        "000000",
                },
                new string[] {
                        "000000",
                        "000000",
                        "000100",
                        "010100",
                        "001100",
                        "000000",
                }
            ).Should().BeTrue();
            PatternTest(
                new string[] {
                        "000000",
                        "000000",
                        "000100",
                        "010100",
                        "001100",
                        "000000",
                },
                new string[] {
                        "000000",
                        "000000",
                        "001000",
                        "000110",
                        "001100",
                        "000000",
                }
            ).Should().BeTrue();
        }

        private bool PatternTest(string[] input, string[] expected_result)
        {
            bool[,] input_matrix = _Transform(input);
            bool[,] expected_matrix = _Transform(expected_result);
            bool[,] actual_matrix = GameHost1.Program.GetNextGenMatrix(input_matrix);

            try
            {
                CompareMatrix(expected_matrix, actual_matrix);
            }
            catch
            {
                return false;
            }

            return true;
        }



        private void CompareMatrix(bool[,] source, bool[,] target)
        {
            if (source == null) throw new ArgumentNullException();
            if (target == null) throw new ArgumentNullException();
            if (source.GetLength(0) != target.GetLength(0)) throw new ArgumentOutOfRangeException();
            if (source.GetLength(1) != target.GetLength(1)) throw new ArgumentOutOfRangeException();

            for (int y = 0; y < source.GetLength(1); y++)
            {
                for (int x = 0; x < source.GetLength(0); x++)
                {
                    if (source[x, y] != target[x, y]) throw new ArgumentException();
                }
            }

            return;
        }

        private bool[,] _Transform(string[] map)
        {
            bool[,] matrix = new bool[map[0].Length, map.Length];

            int x = 0;
            int y = 0;
            foreach (var line in map)
            {
                foreach (var c in line)
                {
                    matrix[x, y] = (c == '1');
                    x++;
                }
                x = 0;
                y++;
            }

            return matrix;
        }

    }
}
