import React, { Fragment } from "react";
import { NavMenu } from "./components/NavMenu";
import { Home } from "./components/Home/Home";
import { Switch, Route } from "react-router-dom";
import { Container } from "react-bootstrap";
import { ToastContainer } from "react-toastify";
import { NetworkError } from "./components/Error/NetworkError";
import { NotFound } from "./components/Error/NotFound";
import { Register } from "./components/Account/Register/Register";
import { Login } from "./components/Account/Login/Login";
import { ProvideAuth } from "./utils/hooks/authHook";
import { List } from "./components/Items/List/List";
import { Details } from "./components/Items/Details/Details";
import { Create } from "./components/Items/Create/Create";
import { PrivateRoute } from "./components/PrivateRoute";
import { Edit } from "./components/Items/Edit/Edit";
import { Admin } from "./components/Admin/Admin";
import { TopUpList } from "./components/Admin/TopUpList";
import { MyContainer } from "./components/Items/List/Container/MyContainer";
import "react-toastify/dist/ReactToastify.css";
import { ProvideBalance } from "./utils/hooks/balance_context";

function App() {
  return (
    <Fragment>
      <ProvideAuth>
        <ProvideBalance>
          <NavMenu />
          <Container className="pt-3">
            <ToastContainer />
            <Switch>
              <Route exact path={["/", "/home"]} component={Home} />
              <Route exact path="/sign-in" component={Login} />
              <Route exact path="/sign-up" component={Register} />
              <Route exact path="/error/network" component={NetworkError} />
              <PrivateRoute adminOnly={true} creatorOnly={true} exact path="/items/create" component={Create} />
              <PrivateRoute path="/items/edit/:slug/:id" component={Edit} />
              <PrivateRoute
                path="/administration"
                adminOnly={true}
                component={Admin}
              />
              <PrivateRoute
                path="/topUpHistory/:userId"
                component={TopUpList}
              />
              <PrivateRoute
                path="/myWinList"
                component={MyContainer}
              />
              <Route exact path="/items/search/:categoryId?/:subCategoryId?" component={List} />
              <Route path="/items/:slug/:id" component={Details} />
              <Route path="*" component={NotFound} />
            </Switch>
          </Container>
        </ProvideBalance>
      </ProvideAuth>
    </Fragment>
  );
}

export default App;
