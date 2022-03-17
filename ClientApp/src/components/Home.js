import React, { Component } from 'react';
import {Helmet} from "react-helmet";

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
                    <Helmet>
                <title>Dot Net 5</title>
            </Helmet>
        <h1>Home</h1>
              </div>
    );
  }
}
