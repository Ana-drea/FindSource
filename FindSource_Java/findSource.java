


import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;

public class findSource {
    public static void main(String[] args) throws IOException {
        ArrayList<String> enulist = new ArrayList<>();
        Scanner sc = new Scanner(System.in);
        System.out.println("Please enter the path of the enu file list:");
        String enulistpath = sc.nextLine();
        File f = new File(enulistpath);
        if (f.isFile()) {
            BufferedReader bf1 = new BufferedReader(new FileReader(f));
            String s;
            while ((s = bf1.readLine()) != null) {
                enulist.add(s);
            }
            String language = null;

            System.out.println("Type in a number to choose a target language:");
            System.out.println("1: deu");
            System.out.println("2. esp");
            System.out.println("3. fra");
            System.out.println("4. ita");
            System.out.println("5. jpn");
            String languagecode = sc.nextLine();
            switch (languagecode) {
                case "1":
                    language = "\\de\\";
                    break;
                case "2":
                    language = "\\es\\";
                    break;
                case "3":
                    language = "\\fr\\";
                    break;
                case "4":
                    language = "\\it\\";
                    break;
                case "5":
                    language = "\\ja\\";
                    break;
                default:
                    System.out.println("Wrong input, end the process");
                    System.exit(1);
            }
            System.out.println("Type in '1' to print out target folder path");
            System.out.println("Type in '2' to start copying to target folder");
            String nextstep = sc.nextLine();
            switch (nextstep) {
                case "1":
                    showTargetLanFolder(enulist, language);
                    break;
                case "2":
                    copyToTargetLanFolder(enulist, language);
                    break;
                default:
                    System.out.println("Wrong input, end the process");
                    System.exit(1);
                    break;
            }


            bf1.close();
        } else {
            System.out.println("Invalid path. Please check your input.");
        }

    }

    public static void copyToTargetLanFolder(ArrayList<String> enulist, String language) throws IOException {
        for (int i = 0; i < enulist.size(); i++) {
            File enufile = new File(enulist.get(i));
            String filename = enufile.getName();
            String targetfolder = enufile.getParent().replace("\\en\\", language);
            File targetFile = new File(targetfolder, filename + "_enu");
            copyFileContent(enufile, targetFile);
        }
    }

    public static void showTargetLanFolder(ArrayList<String> enulist, String language) throws IOException {
        for (int i = 0; i < enulist.size(); i++) {
            File enufile = new File(enulist.get(i));
            String filename = enufile.getName();
            String targetfolder = enufile.getParent().replace("\\en\\", language);
            System.out.println(targetfolder);
        }
    }


    public static void copyFileContent(File source, File target) throws IOException {
        byte[] bys = new byte[1024];
        int len;
        BufferedInputStream bis = new BufferedInputStream(new FileInputStream(source));
        BufferedOutputStream bos = new BufferedOutputStream(new FileOutputStream(target));
        while ((len = bis.read(bys)) != -1) {
            bos.write(bys, 0, len);
        }
        bis.close();
        bos.close();
    }
}
