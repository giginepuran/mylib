/*
 * mylib.c
 *
 *  Created on: 2023/09/20
 *      Author: dai
 */

#include "mylib.h"

int gcd(int a, int b) {
	if (a < b) {
		swap(&a, &b);
	}
	return a%b==0?b:gcd(b,a%b);
}

void swap(int* a, int* b) {
	int buffer = *a;
	*a = *b;
	*b = buffer;
}

void get_prime_table(bool* table, int size) {
	// initialize
	table[0] = false;
	table[1] = false;
	for (int i = 2; i < size; ++i)
		table[i] = true;

	// Sieve of Eratosthenes
	for (int i=2; i<size; ++i) {
		if (!table[i])
			continue;
		for (int j=2*i; j<size; j+=i)
			table[j] = false;
	}
}
