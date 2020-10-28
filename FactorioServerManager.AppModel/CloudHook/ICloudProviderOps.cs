using FactorioServerManager.AppModel.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactorioServerManager.AppModel.CloudHook
{
    interface ICloudProviderOps
    {
        void StartGame(FactorioGame game);
        void StopGame(FactorioGame game);

    }
}
