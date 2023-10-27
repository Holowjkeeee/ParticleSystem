namespace ParticleSystem;

/**
 * Класс испускания частиц
 */
public class ParticleEmitter
{

    public ParticleEmitter()
    {
        CurrentRestoredState = StorageSize;
    }

    #region Properties & Fields
    /** Координата X центра эмиттера */
    public int X;
    
    /** Координата Y центра эмиттера */
    public int Y;
    
    /** Вектор направления в градусах куда сыпет эмиттер */
    public int Direction = 0;
    
    /** Разброс частиц относительно Direction */
    public float Spreading = 360;
    
    /** Начальная минимальная скорость движения частицы */
    public int SpeedMin = 1;
    
    /** Начальная максимальная скорость движения частицы */
    public int SpeedMax = 10;
    
    /** Минимальный радиус частицы */
    public int RadiusMin = 2;
    
    /** Максимальный радиус частицы */
    public int RadiusMax = 10;
    
    /** Минимальное время жизни частицы */
    public int LifeMin = 20;
    
    /** Максимальное время жизни частицы */
    public int LifeMax = 100;
    
    /** Кол-во генерируемых за такт частиц */
    public int ParticlesPerTick = 1;
    
    /** Сила гравитации по X */
    public float GravitationX = 0;
    
    /** Сила гравитации по Y */
    public float GravitationY = 0;
    
    /** Общее количество частиц */
    public int ParticlesCount = 500;
    
    /** Точки притяжения */
    public List<IImpactPoint> impactPoints = new();
    
    /** Частицы */
    public List<Particle> particles = new();
    
    /** Начальный цвет частицы */
    public Color ColorFrom = Color.White;
    
    /** Конечный цвет частиц */
    public Color ColorTo   = Color.FromArgb(0, Color.Black);

    /** Видимость вектора скорости */
    public bool IsSpeedVectorVisible = false;

    /** Память прошлых состояний */
    private List<List<Particle>> StatesStorage = new();

    /** Размер памяти состояний */
    public int StorageSize = 10;

    public int CurrentRestoredState;

    #endregion

    public void UpdateState()
    {
        var particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик

        foreach (var particle in particles)
        {
            
            if (particle.Life == 0) // если частицы умерла
            {
                // то проверяем надо ли создать частицу
                if (particlesToCreate > 0)
                {
                    // сброс частицы равносилен созданию частицы
                    // поэтому уменьшаем счётчик созданных частиц на 1
                    particlesToCreate -= 1; 
                    ResetParticle(particle);
                }
                continue;
            }
            particle.Life -= 1;
            particle.X += particle.SpeedX;
            particle.Y += particle.SpeedY;

            
            particle.IsSpeedVectorVisible = IsSpeedVectorVisible;
            Console.WriteLine("shtsht");

            // каждая точка по-своему воздействует на вектор скорости
            foreach (var point in impactPoints)
            {
                point.ImpactParticle(particle);
            }

            // перерасчет скорости под воздействием гравитации
            particle.SpeedX += GravitationX;
            particle.SpeedY += GravitationY;
            
        }

        // цикл будет срабатывать только в самом начале работы эмиттера
        // пока не накопится критическая масса частиц - ParticlesCount
        while (particlesToCreate >= 1)
        {
            particlesToCreate -= 1;
            var particle = CreateParticle();
            ResetParticle(particle);
            particles.Add(particle);
        }
    }

    public void Render(Graphics g)
    {
        foreach (var particle in particles)
        {
            particle.Draw(g);
        }

        foreach (var point in impactPoints)
        {
            point.Render(g);
        }
    }

    protected virtual void ResetParticle(Particle particle)
    {
        particle.Life = Particle.Rand.Next(LifeMin, LifeMax);
        particle.X = X;
        particle.Y = Y;

        var direction = Direction
                        + (double)Particle.Rand.Next((int)Spreading)
                        - Spreading / 2;

        var speed = Particle.Rand.Next(SpeedMin, SpeedMax);

        particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
        particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

        particle.Radius = Particle.Rand.Next(RadiusMin, RadiusMax);
        particle.IsSpeedVectorVisible = IsSpeedVectorVisible;
    }

    public virtual Particle CreateParticle()
    {
        var particle = new ParticleColorful
        {
            FromColor = ColorFrom,
            ToColor = ColorTo,
            IsSpeedVectorVisible = IsSpeedVectorVisible
        };

        return particle;
    }

    public void SaveState()
    {
        if (StatesStorage.Count == StorageSize)
        {
            StatesStorage.RemoveAt(0);
        }
        StatesStorage.Add(particles);
    }

    public void RestorePreviousState()
    {
        if (CurrentRestoredState == 0) { return; }
        CurrentRestoredState--;
        particles = StatesStorage[CurrentRestoredState];
    }

    public void RestoreNextState()
    {
        if (CurrentRestoredState == StorageSize-1) { return; }
        CurrentRestoredState++;
        particles = StatesStorage[CurrentRestoredState];
    }
}

