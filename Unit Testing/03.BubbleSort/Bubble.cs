using System.Collections;
using System.Collections.Generic;

public class Bubble : IEnumerable<int>
{
    private int[] numbers;

    public Bubble(int[] numbers)
    {
        this.numbers = numbers;
    }

    public int this[int index]
    {
        get => this.numbers[index];
        set => this.numbers[index] = value;
    }

    public void Sort()
    {
        int borderIndex = this.numbers.Length - 1;
        bool swap = true;

        while (swap)
        {
            swap = false;
            for (int i = 0; i < borderIndex; i++)
            {
                if (this.numbers[i] > this.numbers[i + 1])
                {
                    this.Swap(this.numbers[i], this.numbers[i + 1], i);
                    swap = true;
                }
            }

            borderIndex--;
        }
    }

    private void Swap(int biggerNum, int smallerNum, int currentIndex)
    {
        this.numbers[currentIndex] = smallerNum;
        this.numbers[currentIndex + 1] = biggerNum;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.numbers.Length; i++)
        {
            yield return this.numbers[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
