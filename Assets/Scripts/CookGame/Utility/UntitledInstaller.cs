using UnityEngine;
using Zenject;
using sakuGame;
using sakuGame.InputSystem;
using sakuGame.BGM;
using sakuGame.Guzai;
public class UntitledInstaller : MonoInstaller 
{
    [SerializeField]
    GameObject InputObj;
    [SerializeField]
    GameObject TempoObj;
    [SerializeField]
    GameObject CanslashObj;
    
    public override void InstallBindings()
    {
        //.AsSingle　シングルトンのあつかい
        //ASCached インスタンス内にあれば再利用
        //Astranslate そのたびに生成
        //Container.Bind<sakuGame.Guzai.IJudgeEndTime>()
        //    .To<sakuGame.Guzai.CanSlashJudge>()

        //    //.FromComponentsOn(obj)
        //    .AsCached();
        Container.Bind<IInputer>()
            .To<Inputer>()
            .FromComponentOn(InputObj)
            .AsCached();


        Container.Bind<IWhenEndBgm>()
           .To<TempoGenerator>()
           .FromComponentOn(TempoObj)
           .AsCached();

      
        //Container.Bind<IGuzaiSlash>()
        //    .To<CanSlashJudge>()
        //    .FromComponentOn(CanslashObj)
        //    .AsTransient();

        Container.Bind<IMeetCut>()
            .To<Guzai_move>()
            .FromComponentOn(TempoObj)
            .AsCached();
        Container.Bind<IJudgeEndTime>()
            .To<Guzai_move>()
            .FromComponentOn(CanslashObj)
            .AsCached();
        Container.Bind<IWhen_RhythmTiming>()
            .To<Guzai_move>()
            .FromComponentOn(TempoObj)
            .AsCached();
        Container.Bind<IWhen_SlowTiming>()
            .To<Guzai_move>()
            .FromComponentOn(TempoObj)
            .AsCached();

    }
}