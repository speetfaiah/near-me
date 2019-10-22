import React, { Component } from 'react';
import SearchFrom from './components/SearchFrom.jsx';
import Map from './components/Map.jsx';
import ResultList from './components/ResultList.jsx';

class Index extends Component {
    render() {
        return (
            <div className="container">
                <div className="row">
                    <div className="col-4">
                        <SearchFrom />
                    </div>
                    <div className="col-8">
                        <Map />
                    </div>
                </div>
                <div className="row">
                    <ResultList />
                </div>
            </div>
        );
    }
}

export default Index;