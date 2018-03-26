using System;
using System.Collections;
using System.Linq;

public class Clinic : IEnumerable
{

    private Pet[] rooms;
    private int center;
    private int lastPetIndex;

    public Clinic(int rooms)
    {
        this.rooms = new Pet[rooms];
        this.center = this.rooms.Length / 2;
        this.lastPetIndex = -1;
    }

    public bool AddPet(Pet pet)
    {
        if (this.rooms.All(r => r != null))
        {
            return false;
        }
        if (this.lastPetIndex == -1)
        {
            this.rooms[this.center] = pet;
            this.lastPetIndex = this.center;

            return true;
        }

        int currentPetsCount = this.rooms.Count(r => r != null);

        if (currentPetsCount % 2 != 0)
        {
            this.lastPetIndex -= Math.Max(0, currentPetsCount);
        }
        else
        {
            this.lastPetIndex += Math.Min(currentPetsCount, this.rooms.Length - 1);
        }

        this.rooms[this.lastPetIndex] = pet;

        return true;
    }

    public bool Release()
    {
        bool isPetFound = this.SearchPet(this.center, this.rooms.Length - 1);

        if (!isPetFound)
        {
            isPetFound = this.SearchPet(0, this.center);
        }

        return isPetFound;
    }

    public bool HasEmptyRooms()
    {
        return this.rooms.Any(r => r == null);
    }

    public Pet Print(int room)
    {
        return this.rooms[room - 1];
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < this.rooms.Length; i++)
        {
            yield return this.rooms[i];
        }
    }

    private bool SearchPet(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (this.rooms[i] != null)
            {
                this.rooms[i] = null;
                return true;
            }
        }

        return false;
    }
}
