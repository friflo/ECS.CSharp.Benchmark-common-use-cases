#include <iostream>
#include <chrono>

// Windows > cl /O2 query-components-bench.cpp

void execute(int& c1, int& c2, int& c3, int& c4, int& c5)
{
    c1 = c2 + c3 + c4 + c5;
}

void benchmark(int* arr1, int* arr2, int* arr3, int* arr4, int* arr5, int count, int repeat)
{
    for (int i = 0; i < repeat; i++) {
        for (int n = 0; n < count; n++) {
            execute(arr1[n], arr2[n], arr3[n], arr4[n], arr5[n]);
            // arr1[n] = arr2[n] + arr3[n] + arr4[n] + arr5[n];
        }
    }
}

int main()
{
    int count  = 100000;
    int repeat = 10000;

    auto arr1 = new int[count];
    auto arr2 = new int[count];
    auto arr3 = new int[count];
    auto arr4 = new int[count];
    auto arr5 = new int[count];

    std::chrono::steady_clock::time_point begin = std::chrono::steady_clock::now();

    benchmark(arr1, arr2, arr3, arr4, arr5, count, repeat);

    std::chrono::steady_clock::time_point end = std::chrono::steady_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::nanoseconds> (end - begin).count() / repeat;

    std::cout << "entities: " << count << " duration: " << duration << " ns";
}

