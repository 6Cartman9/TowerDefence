namespace TD
{
    public enum Sound 
    {
      BGM = 0,
      Arrow = 1,
      Arrowhit = 2,
      EnemyDie = 3,
      EnemyWin = 4,
      PlayerWin = 5,
      PlayerLose = 6,
      Fireball = 7,
      Crossbowhit = 8,
      bomb = 9,
      Darkmagic = 10,
      FireballHit = 11,
      Crossbow = 12,
      MapMusic = 13,
      LevelMusic = 14,
    }

    public static class SoundExtentions
    {
        public static void Play(this Sound sound)
        {
            SoundPlayer.Instance.Play(sound);
        }
    }
}