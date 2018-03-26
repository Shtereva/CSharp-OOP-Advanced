using System;
using System.Collections.Generic;
using System.Linq;

public class Controller
{
    private Dictionary<string, Clinic> clinics;
    private List<Pet> pets;

    public Controller()
    {
        this.clinics = new Dictionary<string, Clinic>();
        this.pets = new List<Pet>();
    }

    public void CreatePet(string[] cmdArgs)
    {
        string name = cmdArgs[0];
        int age = int.Parse(cmdArgs[1]);
        string kind = cmdArgs[2];

        var pet = new Pet(name, age, kind);
        this.pets.Add(pet);
    }

    public void CreateClinic(string[] cmdArgs)
    {
        string name = cmdArgs[0];
        int rooms = int.Parse(cmdArgs[1]);

        if (rooms % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        if (!this.clinics.ContainsKey(name))
        {
            this.clinics[name] = new Clinic(rooms);
        }
    }

    public bool AddPetToClinic(string[] cmdArgs)
    {
        string petName = cmdArgs[0];
        string clinicName = cmdArgs[1];

        try
        {
            var pet = this.pets.Single(p => p.Name == petName);
            return this.clinics[clinicName].AddPet(pet);
        }
        catch (Exception)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    public bool Release(string[] cmdArgs)
    {
        string clinicName = cmdArgs[0];
        return this.clinics[clinicName].Release();
    }

    public bool HasEmptyRooms(string[] cmdArgs)
    {
        string clinicName = cmdArgs[0];
        return this.clinics[clinicName].HasEmptyRooms();
    }

    public void PrintClinic(string[] cmdArgs)
    {
        string clinicName = cmdArgs[0];
        foreach (var room in this.clinics[clinicName])
        {
            if (room == null)
            {
                Console.WriteLine("Room empty");
                continue;
            }

            Console.WriteLine(room);
        }
    }

    public void PrintClinicRoom(string[] cmdArgs)
    {
        string clinicName = cmdArgs[0];
        int room = int.Parse(cmdArgs[1]);

        var result = this.clinics[clinicName].Print(room);
        Console.WriteLine(result == null ? "Room empty" : result.ToString());
    }
}
