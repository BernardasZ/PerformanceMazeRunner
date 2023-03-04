using System.Threading.Tasks;
using Xunit;

namespace GameRunner.Tests
{
    public class MazeTests
    {
        private readonly IGame _gameRunner;

        public MazeTests()
        {
            _gameRunner = new Game();
        }

        #region Level_0

        [Fact(Timeout = 1_000)]
        public async Task Game_Level_0_Validation_NoFile() => await WrapSyncMethodAsync(@"TestData\map_validation_no_file.txt", 0);

        [Fact(Timeout = 1_000)]
        public async Task Game_Level_0_Validation_NoData() => await WrapSyncMethodAsync(@"TestData\map_validation_no_data.txt", 0);

        [Fact(Timeout = 1_000)]
        public async Task Game_Level_0_Validation_NoX() => await WrapSyncMethodAsync(@"TestData\map_validation_no_x.txt", 0);

        #endregion

        #region Level_1

        [Fact(Timeout = 5_000)]
        public async Task Game_Level_1_1() => await WrapSyncMethodAsync(@"TestData\map_1_1_25x25.txt", 16);

        [Fact(Timeout = 5_000)]
        public async Task Game_Level_1_2() => await WrapSyncMethodAsync(@"TestData\map_1_2_51x51.txt", 66);

        [Fact(Timeout = 5_000)]
        public async Task Game_Level_1_3() => await WrapSyncMethodAsync(@"TestData\map_1_3_69x69.txt", 0);

        #endregion

        #region Level_2

        [Fact(Timeout = 15_000)]
        public async Task Game_Level_2_1() => await WrapSyncMethodAsync(@"TestData\map_2_1_101x101.txt", 77);

        [Fact(Timeout = 15_000)]
        public async Task Game_Level_2_2() => await WrapSyncMethodAsync(@"TestData\map_2_2_150x50.txt", 35);

        [Fact(Timeout = 15_000)]
        public async Task Game_Level_2_3() => await WrapSyncMethodAsync(@"TestData\map_2_3_50x150.txt", 91);

        #endregion

        #region Level_3

        [Fact(Timeout = 30_000)]
        public async Task Game_Level_3_1() => await WrapSyncMethodAsync(@"TestData\map_3_1_200x200.txt", 198);

        [Fact(Timeout = 120_000)]
        public async Task Game_Level_3_2() => await WrapSyncMethodAsync(@"TestData\map_3_2_992x992.txt", 617);

        #endregion

        #region Level_4

        [Fact(Timeout = 300_000)]
        public async Task Game_Level_4_Hardcore() => await WrapSyncMethodAsync(@"TestData\map_4_1_10kx10k.txt", 10754);

        #endregion

        private async Task WrapSyncMethodAsync(string filePath, int expected)
        {
            var task = Task.Factory.StartNew(() =>
            {
                Assert.Equal(expected, _gameRunner.Run(filePath));
            });

            await task;

            Assert.Null(task.Exception);
        }
    }
}