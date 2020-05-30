import java.io.*;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Main {
    static int compare_times = 0;
    static int file_usages = 0;

    static void fibonacciSort(String data, int n) {

        String[] files = {"tmp1.txt", "tmp2.txt", "tmp3.txt"};

        ArrayList<Integer> File1;
        ArrayList<Integer> File2;
        ArrayList<Integer> File3;
        ArrayList<String> FileTemp1;
        ArrayList<String> FileTemp2;
        int firstEmpty = 0;
        int firstNotEmpty = 0;
        int secondNotEmpty = 0;
        int prev = 1;
        int cur = 1;
        int ex;
        compare_times++;
        while (n > cur) {
            compare_times++;
            ex = prev + cur;
            prev = cur;
            cur = ex;
        }

        int fibNum = cur;
        int first = prev;
        int emptyCells = fibNum - n;

        int[] seriesCount = new int[3];

        try {
            //fist pass
            BufferedReader reader = new BufferedReader(new FileReader(data));
            BufferedWriter writer;
            String num_0;
            int counter = 1;
            while ((num_0 = reader.readLine()) != null) {
                file_usages++;
                compare_times++;
                if (counter <= first) {
                    while (emptyCells != 0) {
                        writer = new BufferedWriter(new FileWriter(files[0], true));
                        writer.write("N/A" + "\n");
                        file_usages++;
                        writer.write("~~~" + "\n");
                        file_usages++;
                        emptyCells--;
                        counter++;
                        seriesCount[0]++;
                        writer.close();
                    }
                    writer = new BufferedWriter(new FileWriter(files[0], true));
                    writer.write(num_0 + "\n");
                    file_usages++;
                    writer.write("~~~" + "\n");
                    file_usages++;
                    writer.close();
                    seriesCount[0]++;
                }
                if (counter > first) {
                    writer = new BufferedWriter(new FileWriter(files[1], true));
                    writer.write(num_0 + "\n");
                    file_usages++;
                    writer.write("~~~" + "\n");
                    file_usages++;
                    writer.close();
                    seriesCount[1]++;
                }
                counter++;
            }
            reader.close();

            File1 = new ArrayList<>();
            File2 = new ArrayList<>();
            File3 = new ArrayList<>();
            FileTemp1 = new ArrayList<>();
            FileTemp2 = new ArrayList<>();

            String num_1;
            String num_2;

            int count;
            while (seriesCount[0] + seriesCount[1] + seriesCount[2] > 1) {
                firstNotEmpty = 0;
                secondNotEmpty = 0;
                firstEmpty = 0;

                count = 0;
                // looking for files w/ series and one without one
                for (int i = 0; i < 3; i++) {
                    compare_times++;
                    if (seriesCount[i] > 0) {
                        count++;
                        compare_times++;
                        if (count == 1) {
                            firstNotEmpty = i;
                        } else if (count == 2) {
                            secondNotEmpty = i;
                        }
                    } else {
                        firstEmpty = i;
                    }
                }

                int maxSize = 0;
                compare_times++;
                if (seriesCount[firstNotEmpty] >= seriesCount[secondNotEmpty]) {          // series to read
                    maxSize = seriesCount[secondNotEmpty];
                } else if (seriesCount[firstNotEmpty] < seriesCount[secondNotEmpty]) {
                    maxSize = seriesCount[firstNotEmpty];
                }

                while (maxSize != 0) {
                    BufferedReader reader1 = new BufferedReader(new FileReader(files[firstNotEmpty]));
                    BufferedReader reader2 = new BufferedReader(new FileReader(files[secondNotEmpty]));

                    while ((num_1 = reader1.readLine()) != null) {
                        file_usages++;
                        FileTemp1.add(num_1);
                    }
                    reader1.close();

                    while ((num_2 = reader2.readLine()) != null) {
                        file_usages++;
                        FileTemp2.add(num_2);
                    }
                    reader2.close();


                    reader1 = new BufferedReader(new FileReader(files[firstNotEmpty]));
                    reader2 = new BufferedReader(new FileReader(files[secondNotEmpty]));

                    while ((num_1 = reader1.readLine()) != null) {  // read file
                        file_usages++;
                        FileTemp1.remove(0);
                        compare_times++;
                        if (num_1.equals("~~~")) {
                            seriesCount[firstNotEmpty]--;
                            break;
                        }
                        if (num_1.equals("N/A")) {
                            continue;
                        }
                        File1.add(Integer.parseInt(num_1));
                    }
                    reader1.close();

                    while ((num_2 = reader2.readLine()) != null) {  // read file
                        file_usages++;
                        FileTemp2.remove(0);
                        compare_times++;
                        if (num_2.equals("~~~")) {
                            seriesCount[secondNotEmpty]--;
                            break;
                        }
                        if (num_2.equals("N/A")) {
                            continue;
                        }
                        File2.add(Integer.parseInt(num_2));
                    }
                    reader2.close();

                    File3.addAll(File1); // merge series from files
                    File3.addAll(File2);

                    Collections.sort(File3);

                    BufferedWriter writerEmpty;
                    BufferedWriter writerFirst;
                    BufferedWriter writerSecond;

                    File remFile = new File(files[firstNotEmpty]);
                    remFile.delete();
                    remFile.createNewFile();
                    remFile = new File(files[secondNotEmpty]);
                    remFile.delete();
                    remFile.createNewFile();


                    writerEmpty = new BufferedWriter(new FileWriter(files[firstEmpty], true)); // write to empty file
                    for (Integer integer : File3) {
                        writerEmpty.write(integer + "\n");
                        file_usages++;
                    }
                    writerEmpty.write("~~~" + "\n");
                    file_usages++;

                    seriesCount[firstEmpty]++;

                    writerEmpty.close();

                    writerFirst = new BufferedWriter(new FileWriter(files[firstNotEmpty], true)); // rewrite file
                    for (String s : FileTemp1) {
                        writerFirst.write(s + "\n");
                        file_usages++;
                    }

                    writerFirst.close();

                    writerSecond = new BufferedWriter(new FileWriter(files[secondNotEmpty], true)); // rewrite file
                    for (String s : FileTemp2) {
                        writerSecond.write(s + "\n");
                        file_usages++;
                    }

                    writerSecond.close();

                    FileTemp1.clear();
                    FileTemp2.clear();
                    File1.clear();
                    File2.clear();
                    File3.clear();

                    maxSize--;
                }

            }
//            System.out.println("firstempty:" + firstEmpty + "\nfirstnotempty" + firstNotEmpty + "\nseconnotdempty" + secondNotEmpty);
            // cleanup, output renaming
            File output = new File("Output.txt");
            new File(files[firstEmpty]).renameTo(output);
            new File(files[secondNotEmpty]).delete();
            new File(files[firstNotEmpty]).delete();
            new File(files[firstEmpty]).delete();
        } catch (FileNotFoundException e) {
            System.out.println("File not found.");
        } catch (IOException e) {
            System.out.println("I/O error detected.");
        }
    }


    public static void main(String[] args) {
        try {
            Scanner scanner = new Scanner(System.in);
            System.out.println("Input element count: ");
            int size = scanner.nextInt();

            if (size <= 0) {
                System.out.println("Invalid input");
                return;
            }
            for (int c = 0; c < 7; c++) {
                System.out.println("-----------------------------------");
                compare_times = 0;
                file_usages = 0;
                String filename = "input.txt";
                File _file = new File(filename);
                BufferedWriter writer = new BufferedWriter(new FileWriter(_file));


                for (int i = 0; i < size; i++) {
                    writer.write(i + "\n");
                }
                writer.close();

                long start = System.currentTimeMillis();
                fibonacciSort(filename, size);
                long finish = System.currentTimeMillis();
                long time = finish - start;
                System.out.println("~~~");
                System.out.println("Uprising");
                System.out.println("Time (ms): " + time);
                System.out.println("Compared " + compare_times + " times");
                System.out.println("File used " + file_usages + " times");

                new FileWriter(_file, false).close();
                BufferedWriter writer1 = new BufferedWriter(new FileWriter(_file));

                int k = size;
                for (int i = 0; i < size; i++) {
                    writer1.write(k + "\n");
                    k--;
                }
                writer1.close();

                compare_times = 0;
                file_usages = 0;
                start = System.currentTimeMillis();
                fibonacciSort(filename, size);
                finish = System.currentTimeMillis();
                time = finish - start;
                System.out.println("~~~");
                System.out.println("Downfall");
                System.out.println("Time (ms): " + time);
                System.out.println("Compared " + compare_times + " times");
                System.out.println("File used " + file_usages + " times");

                new FileWriter(_file, false).close();
                BufferedWriter writer2 = new BufferedWriter(new FileWriter(_file));

                for (int i = 0; i < size; i++) {
                    writer2.write((Math.round(Math.random() * 1500) - 750) + "\n");
                }
                writer2.close();

                compare_times = 0;
                file_usages = 0;
                start = System.currentTimeMillis();
                fibonacciSort(filename, size);
                finish = System.currentTimeMillis();
                time = finish - start;
                System.out.println("~~~");
                System.out.println("Random");
                System.out.println("Time (ms): " + time);
                System.out.println("Compared " + compare_times + " times");
                System.out.println("File used " + file_usages + " times");
                System.out.println("~~~");
            }

        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
    }
}