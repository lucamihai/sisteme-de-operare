namespace Laborator8
{
    public static class Constants
    {
        public static int ProgressBarMaxValueRadu = 100000;
        public static int ProgressBarMaxValueCorina = 75000;
        public static int ProgressBarMaxValueMaria = 75000;
        public static int ProgressBarMaxValueMusca = 50000;

        public static int thresholdRadu = ProgressBarMaxValueRadu - ProgressBarMaxValueCorina;
        public static int thresholdCorina = ProgressBarMaxValueRadu - ProgressBarMaxValueMaria;
        public static int thresholdMaria = ProgressBarMaxValueRadu - ProgressBarMaxValueMaria;
    }
}