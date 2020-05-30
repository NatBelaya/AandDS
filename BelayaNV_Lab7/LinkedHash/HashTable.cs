using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedHash
{
	class HashTable
	{
		//array of likedhash elements (key, value, link ->)
		private long TABLE_SIZE;
		private LinkedHash[] table;

		// constructor
		public HashTable(long sz)
		{
			TABLE_SIZE = sz;
			table = new LinkedHash[TABLE_SIZE];
			for (long i = 0; i < TABLE_SIZE; i++)
			{
				table[i] = null;
			}
		}

		/* Function to get value of a key */
		public void PrintValue(long key)
		{
			if (table[key] == null) // not found
			{
				Console.WriteLine("Empty");
				return;
			}

			// read while you can
			LinkedHash entry = table[key];
			while (entry != null)
			{
				Console.Write(entry.Value + " ");
				entry = entry.Next;
			}

		}

		// silet version for speed tests
		public void PrintValueSilent(long key)
		{
			if (table[key] == null) // not found
			{
				return;
			}

			// read while you can
			LinkedHash entry = table[key];
			while (entry != null)
			{
				entry = entry.Next;
			}

		}

		// Add a value
		public void Add(long value)
		{
			long hash = Hash(value) % TABLE_SIZE;
			long key = hash;

			if (table[hash] == null)
				table[hash] = new LinkedHash(key, value);
			else
			{
				LinkedHash entry = table[hash];
				while (entry.Next != null)
					entry = entry.Next;
				entry.Next = new LinkedHash(key, value);
			}
		}

		// Return hashed value
		private long Hash(long val)
		{
			return val * val / 2; // middle of a square
		}

		/* Function to prlong hash table */
		public void PrintTable()
		{
			for (long i = 0; i < TABLE_SIZE; i++)
			{
				Console.Write($"\nBucket {i}: ");
				LinkedHash entry = table[i];
				while (entry != null)
				{
					Console.Write(entry.Value + " ");
					entry = entry.Next;
				}
			}
		}
	}
}
